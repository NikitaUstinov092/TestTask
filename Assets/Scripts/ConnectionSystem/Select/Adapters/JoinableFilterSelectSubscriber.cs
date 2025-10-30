using System;
using ConnectionSystem.EntityFilter;
using Zenject;

namespace ConnectionSystem.Select.Adapters
{
    public class JoinableFilterSelectSubscriber: IInitializable, IDisposable
    {
        private readonly ISelectionHandler _selectionHandler;
        private readonly JoinableStorageManager _joinableStorageManager;
        
        public JoinableFilterSelectSubscriber(ISelectionHandler selectionHandler, JoinableStorageManager joinableStorageManager)
        {
            _selectionHandler = selectionHandler;
            _joinableStorageManager = joinableStorageManager;
        }
        void IInitializable.Initialize()
        {
            _selectionHandler.OnEntitySelected += _joinableStorageManager.UpdateFilter;
            _selectionHandler.OnEntityDeSelected += _joinableStorageManager.ClearStorage;
        }
        void IDisposable.Dispose()
        {
            _selectionHandler.OnEntitySelected -= _joinableStorageManager.UpdateFilter;
            _selectionHandler.OnEntityDeSelected -= _joinableStorageManager.ClearStorage;
        }
    }
}