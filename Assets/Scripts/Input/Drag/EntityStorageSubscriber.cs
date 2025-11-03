using System;
using Entity;
using Zenject;

namespace InputSystem
{
    public class EntityStorageSubscriber: IInitializable, IDisposable
    {
        [Inject] 
        private readonly IEntityStorageObserver _storage;

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

        protected virtual void OnEntityAdded(Entity.Entity entity)
        {
            
        }

        protected virtual void OnEntityRemoved(Entity.Entity entity)
        {
            
        }

        protected virtual void Subscribe(IDragHandler<Entity.Entity> input)
        {
            
        }

        protected virtual void Unsubscribe(IDragHandler<Entity.Entity> input)
        {
           
        }
    }
}