using System;
using Zenject;

namespace GamePlay.ConnectionSystem.Select.Adapters
{
    public class ConnectionSelectResolverAdapter: IInitializable, IDisposable
    {
        private readonly MouseClickValidator _connectionSelectResolver;
        private readonly ConnectionMediator _connectionMediator;
        
        [Inject]
        public ConnectionSelectResolverAdapter(MouseClickValidator connectionSelectResolver, ConnectionMediator connectionMediator)
        {
            _connectionSelectResolver = connectionSelectResolver;
            _connectionMediator = connectionMediator;
        }
        void IInitializable.Initialize()
        {
            _connectionSelectResolver.OnConnectionValid += _connectionMediator.MediateConnection;
        }
        void IDisposable.Dispose()
        {
            _connectionSelectResolver.OnConnectionValid -= _connectionMediator.MediateConnection;
        }
    }
}