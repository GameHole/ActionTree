using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
namespace ActionTree
{
    public interface ITree
    {
        //Entity Entity { get; set; }
        ITree Parent { get; set; }
        //int LocalIndex { get; set; }
        bool Condition { get; }
        void Do();
        bool PreDo();
        void Clear();
        void Apply();
    }
    public abstract class ETree : ITree
    {
        public bool Condition { get; set; }
        public virtual ITree Parent { get; set; }
        //public abstract int LocalIndex { get; set; }

        public abstract void Clear();
        public abstract void Do();
        public abstract bool PreDo();

        Dictionary<Type, IComponent> cmps;
        void tryInit()
        {
            if (cmps == null)
                cmps = new Dictionary<Type, IComponent>();
        }

        public void Add(IComponent component)
        {
            tryInit();
            cmps.Add(component.GetType(), component);
        }

        internal IComponent Get(Type type)
        {
            if (cmps != null)
            {
                cmps.TryGetValue(type, out var component);
                return component;
            }
            return null;
        }

        internal void Remove(Type type)
        {
            if (cmps != null)
            {
                cmps.Remove(type);
            }
        }
        public T Add<T>() where T : IComponent,new()
        {
            tryInit();
            var r = new T();
            cmps.Add(typeof(T), r);
            return r;
        }
        public T Get<T>() where T :class,IComponent
        {
            return Get(typeof(T)) as T;
        }
        public void Remove<T>() where T : IComponent
        {
            Remove(typeof(T));
        }
        public virtual IComponent FindType(Type type) => Get(type);

        public abstract void Apply();
    }
    public delegate void TreeIter(ref ITree tree);
    public static class ITreeEx
    {
        public static void TryDo(this ITree tree)
        {
            if (!tree.Condition)
                tree.Do();
        }
        public static void Foreach(this ITree tree, TreeIter action)
        {
            if(tree is ATreeCntr cntr)
            {
                for (int i = 0; i < cntr.trees.Length; i++)
                {
                    Foreach(cntr.trees[i], action);
                }
            }
            else
            {
                action?.Invoke(ref tree);
            }
        }
    }
}
