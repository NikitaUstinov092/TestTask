using UnityEngine;

namespace GamePlay.ConnectionSystem.Drag.MousePoint
{
    public class MousePointStorage: IMousePointService
    {
        private GameObject _point;
        
        public void SetPoint(GameObject point)
        {
            _point = point;
        }

        public GameObject GetPointGo()
        {
            return _point;
        }
        
        public Transform GetPoint()
        {
            return _point.transform;
        }
        
        public bool PointExists()
        {
            return _point != null;
        }
    }


    public interface IMousePointService
    {
        Transform GetPoint();
    }
}