﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ActionTree
{
    public sealed class WaitOne : ATreeCntr
    {
        public override void Do()
        {
            for (int i = 0; i < Count; i++)
            {
                if (!trees[i].Condition)
                {
                    //UnityEngine.Debug.Log($"one do {trees[i]}");
                    trees[i].Do();
                }
                if (trees[i].Condition)
                {
                    Condition = true;
                    return;
                }
            }
        }
    }
}
