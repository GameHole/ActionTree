using System;
using System.Collections.Generic;
using System.Text;

namespace ActionTree
{
    public sealed class WaitAll : ATreeCntr
    {
        public override void Do()
        {
            bool condition = true;
            for (int i = 0; i < Count; i++)
            {
                if (!trees[i].Condition)
                {
                    trees[i].Do();
                }
                condition &= trees[i].Condition;
            }
            Condition = condition;
            //UnityEngine.Debug.Log($"all {Condition}");
        }
    }
}
