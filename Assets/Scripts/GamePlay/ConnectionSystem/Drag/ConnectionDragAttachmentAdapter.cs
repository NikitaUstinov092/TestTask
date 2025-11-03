using System;
using ConnectionSystem.Connection;
using ConnectionSystem.ConnectionJoin;
using Zenject;

namespace ConnectionSystem
{
    public class ConnectionDragAttachmentAdapter: IInitializable, IDisposable
    {
        private readonly ConnectionDragResolver _dragResolver;
        private readonly IConnectionBuilder _connectionBuilder;
        private readonly IEntityDestroyer _entityDestroyer;
        private readonly ConnectionEndPointSetterFacade _endPointSetterFacade;
        
        [Inject]
        public ConnectionDragAttachmentAdapter(ConnectionDragResolver dragResolver, 
            IConnectionBuilder connectionBuilder, 
            IEntityDestroyer entityDestroyer)
        {
            _dragResolver = dragResolver;
            _connectionBuilder = connectionBuilder;
            _entityDestroyer = entityDestroyer;
            _endPointSetterFacade = new();
        }
        
        void IInitializable.Initialize()
        {
            _dragResolver.OnConnectionResolved += _connectionBuilder.BuildConnection;
            _dragResolver.OnConnectionResolved += _endPointSetterFacade.SetupEndPoint;
            _dragResolver.OnConnectionDiscarded += _entityDestroyer.DestroyEntity;
        }

        void IDisposable.Dispose()
        {
            _dragResolver.OnConnectionResolved -= _connectionBuilder.BuildConnection;
            _dragResolver.OnConnectionResolved -= _endPointSetterFacade.SetupEndPoint;
            _dragResolver.OnConnectionDiscarded -= _entityDestroyer.DestroyEntity;
        }
    }
}