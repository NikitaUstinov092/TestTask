using System;
using ConnectionSystem.Connection;
using ConnectionSystem.ConnectionJoin;
using Zenject;

namespace ConnectionSystem
{
    public class AttachmentSystemAdapter: IInitializable, IDisposable
    {
        private readonly ConnectionResolver _resolver;
        private readonly IConnectionBuilder _connectionBuilder;
        private readonly IEntityDestroyer _entityDestroyer;
        private readonly ConnectionPointSetupWrapper _pointSetupWrapper;
        
        [Inject]
        public AttachmentSystemAdapter(ConnectionResolver resolver, 
            IConnectionBuilder connectionBuilder, 
            IEntityDestroyer entityDestroyer)
        {
            _resolver = resolver;
            _connectionBuilder = connectionBuilder;
            _entityDestroyer = entityDestroyer;
            _pointSetupWrapper = new();
        }
        
        void IInitializable.Initialize()
        {
            _resolver.OnAttached += _connectionBuilder.BuildConnection;
            _resolver.OnAttached += _pointSetupWrapper.SetupEndPoint;
            _resolver.OnDiscard += _entityDestroyer.DestroyEntity;
        }

        void IDisposable.Dispose()
        {
            _resolver.OnAttached -= _connectionBuilder.BuildConnection;
            _resolver.OnAttached -= _pointSetupWrapper.SetupEndPoint;
            _resolver.OnDiscard -= _entityDestroyer.DestroyEntity;
        }
    }
}