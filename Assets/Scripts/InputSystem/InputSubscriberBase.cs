using System;
using Entity;
using Zenject;

namespace InputSystem
{
    public class InputSubscriberBase: IInitializable, IDisposable
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

        protected virtual void OnEntityAdded(Entity.Entity entity)
        {
            
        }

        protected virtual void OnEntityRemoved(Entity.Entity entity)
        {
            
        }
        public virtual void Subscribe(IMouseInput<Entity.Entity> input)
        {
            
        }

        public virtual void Unsubscribe(IMouseInput<Entity.Entity> input)
        {
           
        }
    }
}