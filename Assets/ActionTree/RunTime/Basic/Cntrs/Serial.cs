using System;
using System.Collections.Generic;
using System.Text;

namespace ActionTree
{
    public sealed class Serial : ATreeCntr
    {
        internal int index;
        public override void Clear()
        {
            base.Clear();
            index = 0;
        }
        public override void Do()
        {
            while (index < trees.Length)
            {
                var tree = trees[index];
                if (!tree.Condition)
                {
                    //UnityEngine.Debug.Log($"do {trees[index]}");
                    tree.Do();
                }
                if (!tree.Condition)
                {
                    return;
                }
                index++;
                if (PreDo())
                {
                    return;
                }
            }
            Condition = true;
        }
        public override bool PreDo()
        {
            if (index < trees.Length)
            {
                //UnityEngine.Debug.Log($"serial predo idx::{index} v:: {trees[index]}");
                return trees[index].PreDo();
            }
            return false;
        }
    }
}
