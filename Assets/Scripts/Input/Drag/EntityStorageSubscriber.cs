using System;
using Core.Entity;
using Zenject;

namespace Input.Drag
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

        protected virtual void OnEntityAdded(Entity entity)
        {
            
        }

        protected virtual void OnEntityRemoved(Entity entity)
        {
            
        }

        protected virtual void Subscribe(IDragHandler<Entity> input)
        {
            
        }

        protected virtual void Unsubscribe(IDragHandler<Entity> input)
        {
           
        }
    }
}