using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ActionTree
{
    public class LoopPdr :TreeProvider<Loop>
    {
        public TreeProvider treePdr;
        public override ITree GetTree()
        {
            if (!treePdr)
                throw new System.NullReferenceException(_Stack());
            value.tree = treePdr.tree;
            return base.GetTree();
        }
    }
}
