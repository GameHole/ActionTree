using System;
using System.Collections.Generic;
using System.Text;

namespace ActionTree
{
    public abstract class ATreeCntr : Tree
    {
        public int Count { get; private set; }
        public ITree[] trees;
        public override void Clear()
        {
            //UnityEngine.Debug.Log($"cntr clear {this}");
            Condition = false;
            for (int i = 0; i < Count; i++)
            {
                trees[i].Clear();
                //UnityEngine.Debug.Log($"child clear {trees[i]}");
            }
        }
        public ATreeCntr Add(ITree tree)
        {
            makesurecap(Count + 1);
            trees[Count++] = tree;
            tree.parent = this;
            return this;
        }
        void makesurecap(int c)
        {
            if (trees == null)
            {
                trees = new ITree[1];
            }
            else
            {
                if (c > trees.Length)
                {
                    var newtrees = new ITree[trees.Length * 2];
                    Array.Copy(trees, newtrees, trees.Length);
                    trees = newtrees;
                }
            }
            //UnityEngine.Debug.Log(trees.Length);
        }
        int indexof(Tree tree)
        {
            for (int i = 0; i < trees.Length; i++)
            {
                if (tree == trees[i])
                    return i;
            }
            return -1;
        }
        public ATreeCntr Remove(ITree tree)
        {
            int idx = indexof((Tree)tree);
            if (idx != -1)
            {
                for (int i = idx; i < trees.Length-1; i++)
                {
                    trees[i] = trees[i + 1];
                }
                Count--;
                tree.parent = null;
            }
            return this;
        }
        public ATreeCntr Insert(ITree tree)
        {
            makesurecap(++Count);
            for (int i = trees.Length-1; i >= 0; i--)
            {
                trees[i + 1] = trees[i];
            }
            trees[0] = tree;
            tree.parent = this;
            return this;
        }
        //public abstract void Do();
        public void SetEntity(Entity entity)
        {
            for (int i = 0; i < Count; i++)
            {
                trees[i].entity = entity;
            }
        }

        public override bool PreDo()
        {
            bool a = false;
            for (int i = 0; i < Count; i++)
            {
               a|= trees[i].PreDo();
            }
            return a;
        }
        public override void Apply()
        {
            for (int i = 0; i < Count; i++)
            {
                trees[i].Apply();
            }
        }
    }
}
