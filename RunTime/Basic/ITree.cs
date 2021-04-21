using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
namespace ActionTree
{
    public interface ITree
    {
        Entity entity { get; set; }
        //ITree Parent { get; set; }
        //int LocalIndex { get; set; }
        bool Condition { get; set; }
        void Do();
        bool PreDo();
        void Clear();
        void Apply();
    }
    public abstract class Tree : ITree
    {
        public bool Condition { get; set; }
        public abstract void Clear();
        public abstract void Do();
        public abstract bool PreDo();
        public Entity entity { get; set; }
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
            if (tree is ATreeCntr cntr)
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
    public static class ETreeEx
    {
        public static List<IComponent> FindComponents(this Tree tree, Type type)
        {
            var result = new List<IComponent>();
            var p = tree.entity;
            while (p != null)
            {
                var cmps = p.components;
                if (cmps != null)
                {
                    foreach (var item in cmps.Keys)
                    {
                        if (type.IsAssignableFrom(item))
                        {
                            result.Add(cmps[item]);
                        }
                    }
                }
                p = p.parent;
            }
            return result;
        }
    }
}
