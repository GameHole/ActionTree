using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ActionTree
{
    public class ParallelPdr : TreeCntrProvider<Parallel>
    {
        public bool isLooped;
        public bool notPreDo;
        public override ITree GetTree()
        {
            value.isLooped = isLooped;
            value.usePreDo = !notPreDo;
            return base.GetTree();
        }
    }
}

