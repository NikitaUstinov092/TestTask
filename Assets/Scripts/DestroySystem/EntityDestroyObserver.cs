using System;
using ConnectionSystem.Connection.Components;
using Zenject;

namespace Custom
{
    public class EntityDestroyObserver: IInitializable, IDisposable
    {
        [Inject]
        private EntityDestroyer _entityDestroyer;
        void IInitializable.Initialize()
        {
            _entityDestroyer.OnRequestDestroy += OnRequestDestroy;
        }
        void IDisposable.Dispose()
        {
            _entityDestroyer.OnRequestDestroy -= OnRequestDestroy;
        }
        private void OnRequestDestroy(Entity.Entity entity)
        {
            if (!entity.TryGet(out EntityRelationsComponent entityRelationsComponent)) 
                return;

            var creator = entityRelationsComponent.CreatorEntity;
            
            if(!creator)
                return;
            
            var outgoingConnection = entityRelationsComponent.CreatorEntity.Get<OutgoingConnectionComponent>().OutgoingConnections;
            outgoingConnection.Remove(entity);
        }
    }
}