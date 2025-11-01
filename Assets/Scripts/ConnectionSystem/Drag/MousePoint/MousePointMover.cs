using Custom;
using Zenject;

namespace ConnectionSystem.MousePoint
{
    public class MousePointMover
    {
        [Inject]
        private MousePointStorage _mousePoint;
        
        private TransformMover _transformMover = new();
        
        public void SetStartPoint()
        {
            if(_mousePoint.PointExists()) 
                _transformMover.SetupOffsetScreen(_mousePoint.GetPoint());
        }
        
        public void MovePoint()
        {
            if(_mousePoint.PointExists()) 
                _transformMover.UpdatePosition(_mousePoint.GetPoint());
        }
    }
}
