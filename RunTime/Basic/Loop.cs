using System;
using System.Collections.Generic;
using System.Text;

namespace ActionTree
{
    public sealed class Loop : ATree
    {
        public ITree tree;
        public override void Do()
        {
            Condition = false;
            //UnityEngine.Debug.Log($"clear {tree}");
            tree.Clear();
            tree.PreDo();
        }
        public override void Clear() { }
    }
}
