using System;
using ConnectionSystem.Connection.Components;
using Entity;
using InputSystem;
using InputSystem.Components;
using Zenject;

namespace ConnectionSystem
{
    public abstract class ConnectionInputSubscriberBase : IInitializable, IDisposable
    {
        [Inject] 
        private readonly IEntityStorageObserver _storage;

        public void Initialize()
        {
            _storage.OnEntityAdded += OnEntityAdded;
            _storage.OnEntityRemoved += OnEntityRemoved;
        }

        public void Dispose()
        {
            _storage.OnEntityAdded -= OnEntityAdded;
            _storage.OnEntityRemoved -= OnEntityRemoved;
        }

        private void OnEntityAdded(Entity.Entity entity)
        {
            if (!entity.TryGet(out InputComponent inputComponent)
                || !entity.HasComponent<IncomingConnectionComponent>()) return;

            var input = inputComponent.GetInput();

            Subscribe(input);
        }

        private void OnEntityRemoved(Entity.Entity entity)
        {
            if (!entity.TryGet(out InputComponent inputComponent)
                || !entity.HasComponent<IncomingConnectionComponent>()) return;

            var input = inputComponent.GetInput();

            Unsubsribe(input);
        }

        protected abstract void Subscribe(IMouseInput<Entity.Entity> input);
        protected abstract void Unsubsribe(IMouseInput<Entity.Entity> input);
    }
}