using System;
using System.Collections.Generic;
using System.Text;

namespace ActionTree
{
    public sealed class Parallel : ATreeCntr
    {
        public bool isLooped;
        public bool usePreDo = true;
        public override void Do()
        {
            for (int i = 0; i < Count; i++)
            {
                trees[i].Do();
            }
            if (!isLooped)
                Condition = true;
        }
        public override void Clear()
        {
            if (!isLooped)
                Condition = false;
            for (int i = 0; i < Count; i++)
            {
                trees[i].Clear();
            }
        }
        public override bool PreDo()
        {
            if (usePreDo)
                return base.PreDo();
            return false;
        }
    }
}
