using System;
using Entity;
using Zenject;

namespace InputSystem
{
    public class EntitySubscriptionManager: IInitializable, IDisposable
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
        public virtual void Subscribe(IDragHandler<Entity.Entity> input)
        {
            
        }

        public virtual void Unsubscribe(IDragHandler<Entity.Entity> input)
        {
           
        }
    }
}