﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ActionTree
{
    public class ParallelPdr : TreeCntrProvider<Parallel>
    {
        public bool isLooped;
        public override ETree GetTree()
        {
            value.isLooped = isLooped;
            return base.GetTree();
        }
    }
}

