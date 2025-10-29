using System;
using ConnectionSystem.Connection;
using ConnectionSystem.ConnectionJoin;
using Custom;
using Zenject;

namespace ConnectionSystem
{
    public class AttachmentSystemAdapter: IInitializable, IDisposable
    {
        private readonly ConnectionResolver _resolver;
        private readonly IConnectionBuilder _connectionBuilder;
        private readonly IEntityDestroyer _entityDestroyer;
        
        [Inject]
        public AttachmentSystemAdapter(ConnectionResolver resolver, 
            IConnectionBuilder connectionBuilder, 
            IEntityDestroyer entityDestroyer)
        {
            _resolver = resolver;
            _connectionBuilder = connectionBuilder;
            _entityDestroyer = entityDestroyer;
        }
        
        void IInitializable.Initialize()
        {
            _resolver.OnAttached += _connectionBuilder.BuildConnection;
            _resolver.OnDiscard += _entityDestroyer.DestroyEntity;
        }

        void IDisposable.Dispose()
        {
            _resolver.OnAttached -= _connectionBuilder.BuildConnection;
            _resolver.OnDiscard -= _entityDestroyer.DestroyEntity;
        }
    }
}