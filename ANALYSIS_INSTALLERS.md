# Анализ Zenject ScriptableObject инсталлеров и рекомендации по логическому разделению

## Текущее состояние инсталлеров

### 1. EntityStorageScriptableObjectInstaller
**Категория:** Core  
**Назначение:** Базовое хранилище сущностей  
**Регистрирует:**
- `EntityStorage` (Singleton)

**Анализ:** Базовый инсталлер, необходим для всей системы. Логично оставить отдельно или объединить с другими Core-системами.

---

### 2. SpawnSystemScriptableObjectInstaller
**Категория:** Lifecycle  
**Назначение:** Система создания сущностей  
**Регистрирует:**
- `PawnSpawnAdapter` (Cached)
- `PawnSpawner` (Cached, ExecutionOrder: 100)
- `ConnectionPrefabService` (Singleton, FromComponentsInHierarchy)

**Анализ:** Система спавна связана с жизненным циклом. Можно объединить с Destroy системой.

---

### 3. DestroySystemMonoInstaller
**Категория:** Lifecycle  
**Назначение:** Система уничтожения сущностей  
**Регистрирует:**
- `EntityDestroyer` (Singleton)
- `ConnectionBufferDetector` (Singleton)
- `ConnectionListsExtractor` (Singleton)
- `ConnectionEntityDetector` (Singleton)
- `DetectedConnectionCleanupHandler` (Singleton)
- `ChildEntityCleanupHandler` (Singleton, ExecutionOrder: -10)

**Анализ:** Система уничтожения, тесно связана с жизненным циклом. Логично объединить со Spawn системой.

---

### 4. PawnSystemInstaller
**Категория:** GamePlay  
**Назначение:** Система управления пешками  
**Регистрирует:**
- `ConfigService` (Singleton, FromComponentInHierarchy) ⚠️ TODO: Убрать отсюда
- `PawnPrefabService` (Singleton, FromComponentInHierarchy)
- `PawnMoveSubscriber` (Cached)
- `PawnAreaStateDragAdapter` (Cached)
- `UpdateChildPointsManager` (Cached)
- `PawnConnectionPointsUpdater` (Cached)
- `PawnHighlightController` (Cached)
- `PawnDestroyAdapter` (Cached)

**Анализ:** Много ответственностей:
- Сервисы конфигурации и префабов
- Адаптеры для движения, области, подсветки, уничтожения
- Обновление точек соединения

**Проблемы:**
- `ConfigService` не должен быть здесь (TODO комментарий)
- Смешение адаптеров разных систем (Highlight, Destroy, AreaStatus, Move)

---

### 5. ConnectionSystemsScriptableObjectInstaller
**Категория:** GamePlay/ConnectionSystem  
**Назначение:** Общие системы соединений  
**Регистрирует:**
- `ConnectionBuilder` (Cached)
- `ConnectionLinePointsUpdater` (Singleton)
- `JoinableStorage` (Singleton)
- `JoinableFilterDragSubscriber` (Cached, ExecutionOrder: 30)
- `JoinableStorageManager` (Singleton)
- ExecutionOrder для `ConnectionLineViewDragSubscriber`: 20

**Анализ:** Общая система соединений. Логично объединить с Drag и Select системами.

---

### 6. ConnectionDragSystemScriptableObjectInstaller
**Категория:** GamePlay/ConnectionSystem/Drag  
**Назначение:** Система перетаскивания соединений  
**Регистрирует:**
- `ConnectionDragResolver` (Singleton)
- `ConnectionSpawnWrapper` (Singleton)
- `ConnectionDragSubscriber` (Cached, ExecutionOrder: 10)
- `DragAttachmentSystemAdapter` (Cached)
- `ConnectionLineViewDragSubscriber` (Cached)
- `MousePointStorage` (Singleton)
- `MouseCreatePointDragSubscriber` (Cached)
- `MouseMovePointDragSubscriber` (Cached, ExecutionOrder: 15)
- `ConnectionPointFollower` (Cached)
- `MousePointLifecycle` (Singleton)
- `MousePointMover` (Singleton)

**Анализ:** Система перетаскивания соединений, тесно связана с общей системой соединений.

---

### 7. ConnectionSelectSystemScriptableObjectInstaller
**Категория:** GamePlay/ConnectionSystem/Select  
**Назначение:** Система выбора соединений  
**Регистрирует:**
- `SelectedEntityStorage` (Singleton)
- `ConnectionSelectResolverAdapter` (Cached)
- `ConnectionMediator` (Cached)
- `ConnectionLineViewAdapter` (Cached)
- `JoinableFilterSelectSubscriber` (Cached)
- `MouseClickEntityHandler` (Cached)
- `MouseClickValidator` (Cached)
- `SelectedEntityCleanerAdapter` (Cached)

**Анализ:** Система выбора соединений. Логично объединить с другими системами соединений.

---

### 8. AreaStatusSystemInstaller
**Категория:** GamePlay  
**Назначение:** Система статусов области для сущностей  
**Регистрирует:**
- `EntityAreaStateMediator` (Singleton)
- `EntityAreaStateController` (Singleton)

**Анализ:** Отдельная система статусов. Можно оставить отдельно или объединить с игровой логикой.

---

### 9. HighLightSystemInstaller
**Категория:** Visual  
**Назначение:** Система подсветки сущностей  
**Регистрирует:**
- `EntitySelectionHighlightAdapter` (Cached)

**Анализ:** Минимальная система. Можно оставить отдельно или расширить для других визуальных систем.

---

## Рекомендуемое логическое разделение

### Вариант 1: По доменам (рекомендуется)

#### 1. CoreInstaller
**Объединяет:**
- `EntityStorageScriptableObjectInstaller`
- Возможно будущие базовые системы

**Регистрирует:**
- `EntityStorage`

**Преимущества:**
- Четкое разделение базовых и прикладных систем
- Легко найти базовые зависимости

---

#### 2. LifecycleInstaller
**Объединяет:**
- `SpawnSystemScriptableObjectInstaller`
- `DestroySystemMonoInstaller`

**Регистрирует:**
- Все компоненты спавна и уничтожения
- ExecutionOrder: `ChildEntityCleanupHandler` (-10), `PawnSpawner` (100)

**Преимущества:**
- Логическое объединение жизненного цикла сущностей
- Меньше инсталлеров для управления
- Проще понять порядок инициализации

---

#### 3. PawnInstaller (рефакторинг)
**Текущий:** `PawnSystemInstaller`  
**Что оставить:**
- `PawnPrefabService`
- `PawnMoveSubscriber`
- `UpdateChildPointsManager`
- `PawnConnectionPointsUpdater`

**Что вынести:**
- `ConfigService` → в отдельный `ServicesInstaller` или `ConfigInstaller`
- `PawnHighlightController` → в `VisualInstaller` или расширить `HighLightSystemInstaller`
- `PawnDestroyAdapter` → можно оставить (связь с Pawn), но лучше в `LifecycleInstaller`
- `PawnAreaStateDragAdapter` → в `AreaStatusInstaller` или оставить (зависит от связности)

**Преимущества:**
- Четкая ответственность: только логика пешек
- Сервисы вынесены отдельно
- Адаптеры распределены по соответствующим системам

---

#### 4. ConnectionSystemInstaller
**Объединяет:**
- `ConnectionSystemsScriptableObjectInstaller`
- `ConnectionDragSystemScriptableObjectInstaller`
- `ConnectionSelectSystemScriptableObjectInstaller`

**Регистрирует:**
- Все компоненты систем соединений (Builder, Drag, Select, Joinable)
- Все ExecutionOrder'ы для Connection систем

**Преимущества:**
- Единая точка конфигурации всех систем соединений
- Проще управлять зависимостями между подсистемами
- Логическая группировка связанной функциональности

**Альтернатива:** Оставить разделение, но упорядочить:
- `ConnectionSystemCoreInstaller` (Builder, Storage, Joinable)
- `ConnectionSystemDragInstaller`
- `ConnectionSystemSelectInstaller`

---

#### 5. AreaStatusInstaller
**Текущий:** `AreaStatusSystemInstaller`  
**Оставить как есть** (или расширить, если появятся связанные системы)

**Регистрирует:**
- `EntityAreaStateMediator`
- `EntityAreaStateController`
- Возможно добавить: `PawnAreaStateDragAdapter` из `PawnInstaller`

---

#### 6. VisualInstaller (расширенный)
**Объединяет:**
- `HighLightSystemInstaller`

**Регистрирует:**
- `EntitySelectionHighlightAdapter`
- `PawnHighlightController` (из `PawnInstaller`)
- Возможно будущие визуальные системы

**Преимущества:**
- Единая точка для всех визуальных эффектов
- Легко расширять новыми визуальными системами

---

#### 7. ServicesInstaller (новый)
**Назначение:** Сервисы конфигурации и префабов  
**Регистрирует:**
- `ConfigService` (из `PawnInstaller`)
- `PawnPrefabService` (или оставить в `PawnInstaller`)
- `ConnectionPrefabService` (из `SpawnSystemInstaller`)

**Преимущества:**
- Централизованное управление сервисами
- Легко найти все сервисы

**Альтернатива:** Оставить сервисы в соответствующих системах, но вынести только `ConfigService`.

---

### Вариант 2: Минимальная реорганизация

Оставить большинство инсталлеров как есть, но:
1. Объединить `ConnectionSystemsScriptableObjectInstaller`, `ConnectionDragSystemScriptableObjectInstaller`, `ConnectionSelectSystemScriptableObjectInstaller` → `ConnectionSystemInstaller`
2. Объединить `SpawnSystemScriptableObjectInstaller` и `DestroySystemMonoInstaller` → `LifecycleInstaller`
3. Вынести `ConfigService` из `PawnSystemInstaller` в отдельный `ServicesInstaller` или `ConfigInstaller`

---

## Итоговая структура (рекомендуемый вариант 1)

1. **CoreInstaller** - базовые системы (EntityStorage)
2. **LifecycleInstaller** - спавн и уничтожение
3. **ServicesInstaller** - сервисы (Config, Prefab Services)
4. **PawnInstaller** - система пешек (только логика пешек)
5. **ConnectionSystemInstaller** - все системы соединений
6. **AreaStatusInstaller** - статусы области
7. **VisualInstaller** - все визуальные системы

**Преимущества:**
- ✅ Четкое разделение по доменам
- ✅ Легко найти нужную систему
- ✅ Проще управлять зависимостями
- ✅ Меньше файлов для навигации
- ✅ Логическое группирование связанной функциональности

**Недостатки:**
- ⚠️ Требуется рефакторинг существующих инсталлеров
- ⚠️ Нужно обновить конфигурацию в Unity (ProjectContext/SceneContext)

---

## Порядок выполнения рефакторинга

1. **Этап 1: Объединение Lifecycle**
   - Создать `LifecycleInstaller`
   - Объединить Spawn и Destroy
   - Удалить старые инсталлеры

2. **Этап 2: Объединение Connection**
   - Создать `ConnectionSystemInstaller`
   - Объединить все Connection системы
   - Удалить старые инсталлеры

3. **Этап 3: Рефакторинг Pawn**
   - Вынести `ConfigService` в `ServicesInstaller`
   - Вынести `PawnHighlightController` в `VisualInstaller`
   - Очистить `PawnInstaller`

4. **Этап 4: Создание ServicesInstaller**
   - Создать `ServicesInstaller`
   - Переместить `ConfigService`
   - Опционально: переместить Prefab Services

5. **Этап 5: Расширение VisualInstaller**
   - Переименовать `HighLightSystemInstaller` → `VisualInstaller`
   - Добавить `PawnHighlightController`

6. **Этап 6: Проверка и тестирование**
   - Обновить конфигурацию в Unity
   - Проверить все зависимости
   - Протестировать функциональность

