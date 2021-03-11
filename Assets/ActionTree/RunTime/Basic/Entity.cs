using System;
using System.Collections.Generic;
using System.Text;

namespace ActionTree
{
    public sealed class Entity
    {
        public bool enabled;
        public ITree tree;
        Dictionary<Type, object> components;
        public T AddComponent<T>()where T:class,IComponent,new()
        {
            if (components == null)
                components = new Dictionary<Type, object>();
            var t = new T();
            components.Add(typeof(T), t);
            return t;
        }
        internal void Add(object v)
        {
            if (components == null)
                components = new Dictionary<Type, object>();
            components.Add(v.GetType(), v);
        }
        public T GetComponent<T>()where T:class, IComponent
        {
            if (components == null)
                return null;
            components.TryGetValue(typeof(T), out var t);
            return t as T;
        }
        internal object Get(Type type)
        {
            components.TryGetValue(type, out var t);
            return t;
        }
        public void RemoveComponent<T>()where T : class, IComponent
        {
            components?.Remove(typeof(T));
        }
        public void SetTree(ITree tree)
        {
            this.tree = tree;
            tree.Entity = this;
        }
    }
}
