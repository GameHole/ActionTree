﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ActionTree
{
    public class LoopPdr :TreeProvider<Loop>
    {
        public TreeProvider treePdr;
        public override ITree GetTree()
        {
            value.tree = treePdr.tree;
            return base.GetTree();
        }
    }
}
