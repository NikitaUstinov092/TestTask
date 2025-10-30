using System;
using UnityEngine;
using Zenject;

namespace ConnectionSystem.Select.Adapters
{
    public class ConnectionSelectResolverAdapter: IInitializable, IDisposable
    {
        private readonly ConnectionSelectResolver _connectionSelectResolver;
        private readonly ConnectionMediator _connectionMediator;
        
        [Inject]
        public ConnectionSelectResolverAdapter(ConnectionSelectResolver connectionSelectResolver, ConnectionMediator connectionMediator)
        {
            _connectionSelectResolver = connectionSelectResolver;
            _connectionMediator = connectionMediator;
        }
        void IInitializable.Initialize()
        {
            _connectionSelectResolver.OnConnectionResolved += _connectionMediator.MediateConnection;
        }
        void IDisposable.Dispose()
        {
            _connectionSelectResolver.OnConnectionResolved -= _connectionMediator.MediateConnection;
        }
        
    }
}