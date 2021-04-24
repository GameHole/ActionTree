using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ActionTree
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
    public class Finded : Attribute
    {
        public bool doWhenFind = true;
        public Finded() { }
        public Finded(bool doWhenFind)
        {
            this.doWhenFind = doWhenFind;
        }
    }
    class FindableTree : ITree
    {
        public ATree tree;
        public ATreeCntr cntr;
        public int index;
        //bool findDo; 
        public Entity entity { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool Condition { get => false; set => throw new NotImplementedException(); }

        public void Apply()
        {
            throw new NotImplementedException();
        }

        public void Clear() { }

        public void Do()
        {
            //Init();
            for (int i = tree.needFindInfo.Count - 1; i >= 0; i--)
            {
                var find = tree.driver.FindFirstCmp(tree.needFindInfo[i].FieldType);
                if (find != null)
                {
                    tree.needFindInfo[i].SetValue(tree, find);
                    tree.needFindInfo.Remove(tree.needFindInfo[i]);
                }
            }
            if (tree.needFindInfo.Count == 0)
            {
                cntr.trees[index] = tree;
                //if (findDo)
                //    tree.Do();
            }
        }
        //bool inited;
        //public void Init()
        //{
        //    if (inited) return;
        //    inited = true;

        //    bool r = true;
        //    var ls = tree.needFindInfo;
        //    for (int i = 0; i < ls.Count; i++)
        //    {
        //        r &= ls[i].GetCustomAttribute<Finded>().doWhenFind;
        //    }
        //    findDo = r;
        //}

        public bool PreDo() => false;
    }
}
