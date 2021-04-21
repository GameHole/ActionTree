using System;
using System.Collections.Generic;
using System.Text;

namespace ActionTree
{
    public sealed class Entity
    {
        public Entity parent;
        public List<Entity> childs = new List<Entity>();
        internal Dictionary<Type, IComponent> components = new Dictionary<Type, IComponent>();
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
        public void Remove<T>() where T : class, IComponent
        {
            Remove(typeof(T));
        }
        internal IComponent Get(Type type)
        {
            components.TryGetValue(type, out var t);
            return t;
        }
        internal void Remove(Type type)
        {
            components.Remove(type);
        }
        public IComponent FindComponent(Type type)
        {
            IComponent cmp = Get(type);
            var p = parent;
            while (cmp == null && p != null)
            {
                cmp = p.Get(type);
                p = p.parent;
            }
            return cmp;
        }
        public IList<IComponent> FindAll(Type type)
        {
            List<IComponent> components = new List<IComponent>();
            var parnet = this;
            while (parnet != null)
            {
                //UnityEngine.Debug.Log($"finding {item.FieldType} ::{parnet}");
                var cmp = parnet.Get(type);
                if (cmp != null)
                    components.Add(cmp);
                parnet = parnet.parent;
            }
            return components;
        }
    }
}
