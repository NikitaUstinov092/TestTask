using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Entity
{
    public class Entity : MonoBehaviour
    {
        [SerializeField]
        private List<MonoBehaviour> _components;

        public void Add<T>(T comp) where T: MonoBehaviour
        {
            _components ??= new ();
            _components.Add(comp);
        }

        public void RemoveComponent<T>(T _) where T : MonoBehaviour
        {
            foreach (var component in _components.ToList())
            {
                if(component is T)
                    _components.Remove(component);
            }
        }
        public T Get<T>()
        {
            for (int i = 0, count = _components.Count; i < count; i++)
            {
                var component = _components[i];
                if (component is T result)
                {
                    return result;
                }
            }

            throw new Exception($"Component of type {typeof(T).Name} is not found! {this.gameObject.name}");
        }

        public bool TryGet<T>(out T result)
        {
            for (int i = 0, count = _components.Count; i < count; i++)
            {
                var component = _components[i];
                if (component is T tComponent)
                {
                    result = tComponent;
                    return true;
                }
            }

            result = default;
            return false;
        }

        public bool HasComponent<T>()
        {
            for (int i = 0, count = _components.Count; i < count; i++)
            {
                var component = _components[i];
                if (component is T tComponent)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
