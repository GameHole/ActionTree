using System;
using System.Collections.Generic;
using System.Text;

namespace ActionTree
{
    public sealed class Entity : IEquatable<Entity>
    {
        static uint seed;
        public Entity()
        {
            id = ++seed;
            //UnityEngine.Debug.Log($"make ::{id}");
        }
        public uint id;
        Entity _parent;
        public Entity parent
        {
            get => _parent;
            set
            {
                _parent = value;
                if (value!=null)
                {
                    value.childs.Add(this);
                }
            }
        }
        public List<Entity> childs = new List<Entity>();
        internal Dictionary<Type, IComponent> components = new Dictionary<Type, IComponent>();
        public IEnumerable<Type> CmpTypes
        {
            get => components.Keys;
        }
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
        internal void AddImpl<T>(IComponent v)
        {
            components.Add(typeof(T), v);
        }
        public bool Set(IComponent value)
        {
            var type = value.GetType();
            if (!components.ContainsKey(type))
                return false;
            components[type] = value;
            return true;
        }
        public bool Set<T>(IComponent value) where T:IComponent
        {
            var type = typeof(T);
            if (!components.ContainsKey(type))
                return false;
            components[type] = value;
            return true;
        }
        public T Get<T>() where T : class, IComponent
        {
            return Get(typeof(T)) as T;
        }
        public void Remove<T>() where T : class, IComponent
        {
            Remove(typeof(T));
        }
        public IComponent Get(Type type)
        {
            components.TryGetValue(type, out var t);
            return t;
        }
        internal void Remove(Type type)
        {
            components.Remove(type);
        }
        internal IComponent FindComponent(Type type, bool containThis = true)
        {
            IComponent cmp = containThis ? Get(type) : null;
            var p = parent;
            while (cmp == null && p != null)
            {
                cmp = p.Get(type);
                p = p.parent;
            }
            return cmp;
        }
        public T FindComponent<T>()where T :class, IComponent
        {
            return FindComponent(typeof(T)) as T;
        }
        IComponent _FindImplementCmp(Type baseicType)
        {
            foreach (var item in components.Keys)
            {
                if (baseicType.IsAssignableFrom(item))
                {
                    return components[item];
                }
            }
            return null;
        }
        public IComponent FindImplement(Type type, bool containThis = true)
        {
            IComponent cmp = containThis ? _FindImplementCmp(type) : null;
            var p = parent;
            while (cmp == null && p != null)
            {
                cmp = p._FindImplementCmp(type);
                p = p.parent;
            }
            return cmp;
        }
        public T FindImplement<T>(bool containThis = true)
        {
            return (T)FindImplement(typeof(T), containThis);
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
        public T FindChild<T>() where T:class,IComponent
        {
            for (int i = 0; i < childs.Count; i++)
            {
                var t = childs[i].Get<T>();
                if (t != null)
                    return t;
            }
            return null;
        }
        public List<Entity> FindChild(params Type[] types)
        {
            List<Entity> es = new List<Entity>();
            for (int i = 0; i < childs.Count; i++)
            {
                if (childs[i].ContainAll(types))
                {
                    es.Add(childs[i]);
                }
            }
            return es;
        }
        public IList<T> FindAll<T>()where T:class,IComponent
        {
            List<T> components = new List<T>();
            var parnet = this;
            while (parnet != null)
            {
                //UnityEngine.Debug.Log($"finding {item.FieldType} ::{parnet}");
                var cmp = parnet.Get(typeof(T));
                if (cmp != null)
                    components.Add((T)cmp);
                parnet = parnet.parent;
            }
            for (int i = 0; i < childs.Count; i++)
            {
                var cmp = childs[i].Get<T>();
                if (cmp != null)
                    components.Add(cmp);
            }
            return components;
        }
        public bool ContainAll(Type[] types)
        {
            if (components.Count == 0) return false;
            for (int i = 0; i < types.Length; i++)
            {
                if (!components.ContainsKey(types[i])) return false;
            }
            return true;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Entity);
        }

        public bool Equals(Entity other)
        {
            return other != null &&
                   id == other.id;
        }

        public override int GetHashCode()
        {
            return 1877310944 + id.GetHashCode();
        }
        public int GetCmpHash()
        {
            int hash = 0;
            foreach (var item in components.Keys)
            {
                hash += item.GetHashCode();
            }
            return hash;
        }
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(id);
            builder.Append('\n');
            foreach (var item in components.Keys)
            {
                builder.Append(item);
                builder.Append('\n');
            }
            return builder.ToString();
        }
    }
}
