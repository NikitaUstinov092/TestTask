using Custom;
using Zenject;

namespace ConnectionSystem.MousePoint
{
    public class MousePointMover
    {
        [Inject]
        private MousePointStorage _mousePoint;
        
        private TransformDragger _transformDragger = new();
        
        public void SetStartPoint()
        {
            if(_mousePoint.PointExists()) 
                _transformDragger.BeginDrag(_mousePoint.GetPoint());
        }
        
        public void MovePoint()
        {
            if(_mousePoint.PointExists()) 
                _transformDragger.UpdateDrag(_mousePoint.GetPoint());
        }
    }
}
