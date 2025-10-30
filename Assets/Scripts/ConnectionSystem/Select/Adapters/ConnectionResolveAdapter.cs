using System;
using Zenject;

namespace ConnectionSystem.Select.Adapters
{
    public class ConnectionResolveAdapter: IInitializable, IDisposable
    {
        private readonly ConnectionSelectResolver _connectionSelectResolver;
        private readonly ISelectionCleanupRequestHandler _selectionCleanupRequestHandler;
        
        [Inject]
        public ConnectionResolveAdapter(ConnectionSelectResolver connectionSelectResolver, ISelectionCleanupRequestHandler selectionCleanupRequestHandler)
        {
            _connectionSelectResolver = connectionSelectResolver;
            _selectionCleanupRequestHandler = selectionCleanupRequestHandler;
        }
        void IInitializable.Initialize()
        {
            _selectionCleanupRequestHandler.OnSelectionClearRequest += _connectionSelectResolver.ResolveConnection;
        }

        void IDisposable.Dispose()
        {
            _selectionCleanupRequestHandler.OnSelectionClearRequest -= _connectionSelectResolver.ResolveConnection;
        }
    }
}