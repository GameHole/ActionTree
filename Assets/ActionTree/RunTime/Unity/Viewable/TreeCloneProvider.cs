using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ActionTree
{
    public class TreeCloneProvider : TreeProvider
    {
        public TreeProvider provider;
        public override ITree tree => provider.tree;

        public override ITree GetTree()
        {
           return Clone();
        }

        internal override Type TreeType()
        {
            return null;
        }
        internal override ITree Clone()
        {
            var ret = provider.Clone();
            if (tempEntity != null)
                ret.entity = tempEntity;
            return ret;
        }
    }
}

