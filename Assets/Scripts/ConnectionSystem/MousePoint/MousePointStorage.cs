using UnityEngine;

namespace ConnectionSystem.MousePoint
{
    public class MousePointStorage: IMousePointService
    {
        private Transform _point;
        
        public void SetPoint(Transform point)
        {
            _point = point;
        }

        public void RemovePoint()
        {
            _point = null;
        }
        
        Transform IMousePointService.GetPoint()
        {
            return _point;
        }
    }


    public interface IMousePointService
    {
        Transform GetPoint();
    }
}