using System;
using System.Collections.Generic;
using System.Text;

namespace ActionTree
{
    public sealed class Serial : ATreeCntr
    {
        int index;
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
                PreDo();
            }
            Condition = true;
        }
        public override void PreDo()
        {
            if (index < trees.Length)
            {
                trees[index].PreDo();
                //UnityEngine.Debug.Log($"predo {trees[index]}");
            }
        }
    }
}
