using System;
using GamePlay.ConnectionSystem.Join.JoinableFilter;
using Zenject;

namespace GamePlay.ConnectionSystem.Select.Adapters
{
    public class JoinableFilterSelectAdapter: IInitializable, IDisposable
    {
        private readonly ISelectionHandler _selectionHandler;
        private readonly JoinableStorageManager _joinableStorageManager;
        
        public JoinableFilterSelectAdapter(ISelectionHandler selectionHandler, JoinableStorageManager joinableStorageManager)
        {
            _selectionHandler = selectionHandler;
            _joinableStorageManager = joinableStorageManager;
        }
        void IInitializable.Initialize()
        {
            _selectionHandler.OnEntitySelected += _joinableStorageManager.RefreshCandidatesFor;
            _selectionHandler.OnEntityDeSelected += _joinableStorageManager.ClearStorage;
        }
        void IDisposable.Dispose()
        {
            _selectionHandler.OnEntitySelected -= _joinableStorageManager.RefreshCandidatesFor;
            _selectionHandler.OnEntityDeSelected -= _joinableStorageManager.ClearStorage;
        }
    }
}