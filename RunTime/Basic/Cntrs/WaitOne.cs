using System;
using System.Collections.Generic;
using System.Text;

namespace ActionTree
{
    public sealed class WaitOne : ATreeCntr
    {
        public override void Do()
        {
            for (int i = 0; i < trees.Length; i++)
            {
                if (!trees[i].Condition)
                    trees[i].Do();
                if (trees[i].Condition)
                {
                    Condition = true;
                    return;
                }
            }
        }
    }
}
