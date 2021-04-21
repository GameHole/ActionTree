using System;
using System.Collections.Generic;
using System.Text;

namespace ActionTree
{
    public sealed class Entity
    {
        Entity parent;
        Dictionary<Type, IComponent> components = new Dictionary<Type, IComponent>();
        public T Add<T>() where T : class, IComponent, new()
        {
            var t = new T();
            Add(t);
            return t;
        }
        public void Add(IComponent v)
        {
            components.Add(v.GetType(), v);
        }
        public T Get<T>() where T : class, IComponent
        {
            return Get(typeof(T)) as T;
        }
        internal IComponent Get(Type type)
        {
            components.TryGetValue(type, out var t);
            return t;
        }
    }
}
