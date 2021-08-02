using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ActionTree
{
    public class SelectOnePdr : TreeCntrProvider<SelectOne>
    {
        public bool ignoreChildCondition;
        public override ITree GetTree()
        {
            var t = base.GetTree();
            if (value.Count < 2)
                throw new System.ArgumentException($"SelectOne must hae 2 child and 1 optional child,the first is condition ,second is true route,thried is false route\n{name}");
            value.ignoreChildCondition = ignoreChildCondition;
            return t;
        }
    }
}

