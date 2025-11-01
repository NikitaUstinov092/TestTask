using System;
using ConnectionSystem.Connection;
using ConnectionSystem.ConnectionJoin;
using Zenject;

namespace ConnectionSystem
{
    public class DragAttachmentSystemAdapter: IInitializable, IDisposable
    {
        private readonly ConnectionDragResolver _dragResolver;
        private readonly IConnectionBuilder _connectionBuilder;
        private readonly IEntityDestroyer _entityDestroyer;
        private readonly ConnectionPointPositionSetupWrapper _pointPositionSetupWrapper;
        
        [Inject]
        public DragAttachmentSystemAdapter(ConnectionDragResolver dragResolver, 
            IConnectionBuilder connectionBuilder, 
            IEntityDestroyer entityDestroyer)
        {
            _dragResolver = dragResolver;
            _connectionBuilder = connectionBuilder;
            _entityDestroyer = entityDestroyer;
            _pointPositionSetupWrapper = new();
        }
        
        void IInitializable.Initialize()
        {
            _dragResolver.OnConnectionResolved += _connectionBuilder.BuildConnection;
            _dragResolver.OnConnectionResolved += _pointPositionSetupWrapper.SetupEndPoint;
            _dragResolver.OnDiscard += _entityDestroyer.DestroyEntity;
        }

        void IDisposable.Dispose()
        {
            _dragResolver.OnConnectionResolved -= _connectionBuilder.BuildConnection;
            _dragResolver.OnConnectionResolved -= _pointPositionSetupWrapper.SetupEndPoint;
            _dragResolver.OnDiscard -= _entityDestroyer.DestroyEntity;
        }
    }
}