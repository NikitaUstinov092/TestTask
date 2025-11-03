using Core.Entity;
using GamePlay.ConnectionSystem.Components;
using Input.Drag;
using Zenject;

namespace GamePlay.ConnectionSystem.Drag.Subscribers
{
    public class ConnectionLineViewDragSubscriber: BaseConnectionDragSubscriber
    {
        [Inject]
        private IConnectionLinePointUpdater _connectionLinePointsUpdater;

        protected override void Subscribe(IDragHandler<Entity> input)
        {
            input.OnBeginDragEventData += OnBeginDragEventData; 
            input.OnDragEventData += OnDragEventData; 
            input.OnEndDragEventData += OnEndDragEventData; 
        }
        protected override void Unsubscribe(IDragHandler<Entity> input)
        {
            input.OnBeginDragEventData -= OnBeginDragEventData; 
            input.OnDragEventData -= OnDragEventData; 
            input.OnEndDragEventData -= OnEndDragEventData; 
        }
        private void OnBeginDragEventData(Entity entity)
        {
            if(!entity.TryGet(out ConnectionBufferComponent connectionBufferComponent))
                return;
            
            _connectionLinePointsUpdater.UpdateLineStartPoint(connectionBufferComponent.ConnectionBufferEntity);
        }
        private void OnDragEventData(Entity entity)
        {
            if(!entity.TryGet(out ConnectionBufferComponent connectionBufferComponent))
                return;
            
            _connectionLinePointsUpdater.UpdateLineEndPoint(connectionBufferComponent.ConnectionBufferEntity);
        }
        private void OnEndDragEventData(Entity entity)
        {
           if(!entity.TryGet(out ConnectionBufferComponent connectionBufferComponent))
               return;
           
           _connectionLinePointsUpdater.UpdateLineEndPoint(connectionBufferComponent.ConnectionBufferEntity);
        }

      

       

        
        
    }
}