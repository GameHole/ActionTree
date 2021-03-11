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
            //UnityEngine.Debug.Log("clear0");
            tree.Clear();
            tree.PreDo();
        }
        public override void Clear() { }
    }
}
