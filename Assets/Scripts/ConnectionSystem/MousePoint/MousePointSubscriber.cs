using System;
using Zenject;

namespace MousePoint
{
    public class MousePointSubscriber: IInitializable, IDisposable
    {
        private readonly EntityStorage _storage;
        private readonly MousePointSpawner _mousePointSpawner;
        
        [Inject]
        public MousePointSubscriber(EntityStorage storage, MousePointSpawner mousePointSpawner)
        {
            _storage = storage;
            _mousePointSpawner = mousePointSpawner;
        }
        void IInitializable.Initialize()
        {
            _storage.OnEntityAdded += OnEntityAdded;
            _storage.OnEntityRemoved += OnEntityRemoved;
        }
        void IDisposable.Dispose()
        {
            _storage.OnEntityAdded -= OnEntityAdded;
            _storage.OnEntityRemoved -= OnEntityRemoved;
        }
        
        private void OnEntityAdded(Entity.Entity entity)
        {
            if (!entity.TryGet(out InputComponent inputComponent)
                || !entity.HasComponent<IncomingConnectionComponent>()) return;
        
            var input = inputComponent.GetInput();
     
            input.OnBeginDragData += _mousePointSpawner.OnBeginDrag;
            input.OnDragEvent += _mousePointSpawner.OnDrag;
            input.OnPointerUpData += _mousePointSpawner.OnMouseUp;
        }

        private void OnEntityRemoved(Entity.Entity entity)
        {
            if (!entity.TryGet(out InputComponent inputComponent)
                || !entity.HasComponent<IncomingConnectionComponent>()) return;
        
            var input = inputComponent.GetInput();
       
            input.OnBeginDragData -= _mousePointSpawner.OnBeginDrag;
            input.OnDragEvent -= _mousePointSpawner.OnDrag;
            input.OnPointerUpData -= _mousePointSpawner.OnMouseUp;
        }
    }
}