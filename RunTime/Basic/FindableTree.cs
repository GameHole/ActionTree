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
        internal List<Type> types;
        public Finded() { }
        public Finded(params Type[] types)
        {
            this.types = new List<Type>();
            this.types.AddRange(types);
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
        public bool Condition { get; set; }

        public void Apply()
        {
            throw new NotImplementedException();
        }

        public void Clear() { }

        public void Do()
        {
            //Init();
            //UnityEngine.Debug.Log($"find {injectedTree} { injectedTree.needFindInfo.Count}");
            Condition = false;
            var fields = injectedTree.needFindInfo;
            for (int i = fields.Count - 1; i >= 0; i--)
            {
                var field = fields[i];
                var extra = field.GetCustomAttribute<Finded>();
                object find = null;
                if (extra.types == null)
                {
                    find = injectedTree.driver.FindFirstCmp(field.FieldType);
                }
                else
                {
                    var e = injectedTree.driver.FindEntityWith(extra.types.ToArray());
                    if (e != null)
                    {
                        find = e.Get(field.FieldType);
                    }
                }
                if (find != null)
                {
                    field.SetValue(injectedTree, find);
                    injectedTree.needFindInfo.Remove(field);
                }
            }
            if (fields.Count == 0)
            {
                cntr.trees[index] = repleasedTree;
                //if (findDo)
                //    tree.Do();
                Condition = true;
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
