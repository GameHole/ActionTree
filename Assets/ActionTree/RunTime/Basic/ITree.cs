using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
namespace ActionTree
{
    public interface ITree
    {
        string Name { get; set; }
        ITree parent { get; set; }
        

        Entity entity { get; set; }
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
        public virtual string Name { get; set; }
        public ITree parent { get; set; }

        public abstract void Apply();

    }
    public delegate void TreeIter(ref ITree tree);
    public static partial class ITreeEx
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
                for (int i = 0; i < cntr.Count; i++)
                {
                    Foreach(cntr.trees[i], action);
                }
            }
            else
            {
                action?.Invoke(ref tree);
            }
        }
        //public static void Log(this ITree tree, object v)
        //{
        //    _Log(tree, v);
        //}
        //public static void Error(this ITree tree, object v)
        //{
        //    _Error(tree, v);
        //}
        //public static void Warning(this ITree tree, object v)
        //{
        //    _Warning(tree, v);
        //}
        //static partial void _Log(this ITree tree, object v);
        //static partial void _Error(this ITree tree, object v);
        //static partial void _Warning(this ITree tree, object v);
        public static string debug(this ITree tree ,object v)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(v);
            builder.Append("\nRoute:");
            var p = tree;
            while (p != null)
            {
                builder.Append(p.Name);
                if (p.parent != null)
                    builder.Append("->");
                p = p.parent;
            }
            return builder.ToString();
        }
        public static string stack(this ITree tree)
        {
            StringBuilder builder = new StringBuilder();
            var p = tree;
            while (p != null)
            {
                builder.Append(p.Name);
                if (p.parent != null)
                    builder.Append("->");
                p = p.parent;
            }
            return builder.ToString();
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
