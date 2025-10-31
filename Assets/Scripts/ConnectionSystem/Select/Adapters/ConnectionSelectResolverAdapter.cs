using System;
using Zenject;

namespace ConnectionSystem.Select.Adapters
{
    public class ConnectionSelectResolverAdapter: IInitializable, IDisposable
    {
        private readonly RayCastInputMediator _connectionSelectResolver;
        private readonly ConnectionMediator _connectionMediator;
        
        [Inject]
        public ConnectionSelectResolverAdapter(RayCastInputMediator connectionSelectResolver, ConnectionMediator connectionMediator)
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