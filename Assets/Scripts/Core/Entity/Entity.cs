using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Core.Entity
{
    public class Entity : MonoBehaviour
    {
        [SerializeField]
        private List<MonoBehaviour> _components;
        
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
