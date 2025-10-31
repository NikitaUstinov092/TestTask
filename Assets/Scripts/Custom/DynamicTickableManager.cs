using System.Linq;
using UnityEngine;
using Zenject;

namespace Custom
{
    public class DynamicTickableManager
    {
        private readonly TickableManager _tickableManager;
        private readonly DiContainer _container;
      
        private ITickable _currentTickable;
        private ILateTickable _currentLateTickable;

        public DynamicTickableManager(DiContainer container)
        {
            _tickableManager = container.Resolve<TickableManager>();
            _container = container;
        }

        public void AddTickable<T>() where T : ITickable
        {
            if (_currentTickable != null) 
                return;
            
            _currentTickable = _container.Instantiate<T>();
            _tickableManager.Add(_currentTickable);
            Debug.Log("Tickable Добавлен");
        }
        
        public void AddLateTickable<T>() where T : ILateTickable
        {
            if (_currentLateTickable != null) 
                return;
            
            _currentLateTickable = _container.Instantiate<T>();
            _tickableManager.AddLate(_currentLateTickable); // ПРАВИЛЬНО: используем AddLate()
        }

        public void RemoveTickable()
        {
            if (_currentTickable == null) 
                return;
        
            _tickableManager.Remove(_currentTickable);
            
            if (_currentTickable is System.IDisposable disposable)
                disposable.Dispose();
                
            _currentTickable = null;
            Debug.Log("Tickable Удален");
        }

        public void RemoveLateTickable()
        {
            if (_currentLateTickable == null) 
                return;
        
            _tickableManager.RemoveLate(_currentLateTickable);
            
            if (_currentLateTickable is System.IDisposable disposable)
                disposable.Dispose();
                
            _currentLateTickable = null;
        }

        public void RemoveAll()
        {
            RemoveTickable();
            RemoveLateTickable();
        }
    }
}