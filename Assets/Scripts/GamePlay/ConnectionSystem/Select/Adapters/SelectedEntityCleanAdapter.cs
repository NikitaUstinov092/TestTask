using System;
using Input.Select;
using Zenject;

namespace GamePlay.ConnectionSystem.Select.Adapters
{
    public class SelectedEntityCleanAdapter: IInitializable, IDisposable
    {
        private readonly MouseStartDragHandler _mouseStartDragHandler;
        private readonly SelectedEntityStorage _entityStorage; 
        
        [Inject]
        public SelectedEntityCleanAdapter(MouseStartDragHandler mouseStartDragHandler, SelectedEntityStorage entityStorage)
        {
            _mouseStartDragHandler = mouseStartDragHandler;
            _entityStorage = entityStorage;
        }
        void IInitializable.Initialize()
        {
            _mouseStartDragHandler.OnBeginDrag += _entityStorage.ClearSelection;
        }
        void IDisposable.Dispose()
        {
            _mouseStartDragHandler.OnBeginDrag -= _entityStorage.ClearSelection;
        }
    }
}