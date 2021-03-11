using System;
using System.Collections.Generic;
using System.Text;

namespace ActionTree
{
    public abstract class ATreeCntr : ITree
    {
        public bool Condition { get; set; }
        public Entity Entity
        {
            get => entity;
            set
            {
                entity = value;
                SetEntity(value);
            }
        }
        Entity entity;
        List<ITree>  listtrees = new List<ITree>();
        public ITree[] trees;
        public virtual void Clear()
        {
            Condition = false;
            for (int i = 0; i < trees.Length; i++)
            {
                trees[i].Clear();
            }
        }
        public ATreeCntr Add(ITree tree)
        {
            listtrees.Add(tree);
            return this;
        }
        public ATreeCntr Remove(ITree tree)
        {
            listtrees.Remove(tree);
            return this;
        }
        public ATreeCntr Insert(ITree tree)
        {
            listtrees.Insert(0,tree);
            return this;
        }
        public abstract void Do();
        public void SetEntity(Entity entity)
        {
            trees = listtrees.ToArray();
            for (int i = 0; i < trees.Length; i++)
            {
                trees[i].Entity = entity;
            }
            listtrees.Clear();
            listtrees = null;
        }

        public virtual void PreDo()
        {
            for (int i = 0; i < trees.Length; i++)
            {
                trees[i].PreDo();
            }
        }
    }
}
