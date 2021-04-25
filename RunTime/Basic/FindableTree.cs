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
        public ATree injectedTree;
        public ITree repleasedTree;
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
            //UnityEngine.Debug.Log($"find {tree} { tree.needFindInfo.Count}");
            for (int i = injectedTree.needFindInfo.Count - 1; i >= 0; i--)
            {
                var find = injectedTree.driver.FindFirstCmp(injectedTree.needFindInfo[i].FieldType);
                if (find != null)
                {
                    injectedTree.needFindInfo[i].SetValue(injectedTree, find);
                    injectedTree.needFindInfo.Remove(injectedTree.needFindInfo[i]);
                }
            }
            if (injectedTree.needFindInfo.Count == 0)
            {
                cntr.trees[index] = repleasedTree;
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
