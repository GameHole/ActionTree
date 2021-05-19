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
            while (index < Count)
            {
                var tree = trees[index];
                tree.TryDo();
                //this.Log($"do {tree.Name} {tree.Condition} ");
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
            if (index < Count)
            {
                //this.Log($"pre do {trees[index].Name} {trees[index].Condition} ");
                //UnityEngine.Debug.Log($"serial predo idx::{index} v:: {trees[index]}");
                return trees[index].PreDo();
            }
            return false;
        }
    }
}
