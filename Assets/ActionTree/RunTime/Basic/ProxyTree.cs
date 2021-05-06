using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ActionTree
{
    class ProxyTree : ITree
    {
        public ITree tree;
        //public Entity Entity { get; set; }
        public bool Condition { get => tree.Condition; set => throw new NotImplementedException(); }

        public ITree Parent { get ; set ; }
        public Entity entity { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Name { get =>$"{tree.Name}.Proxy"; set => throw new NotImplementedException(); }
        public ITree parent { get => tree.parent; set => throw new NotImplementedException(); }

        public Worker worker;
        public bool usePredo = true;
        public void Clear()
        {
            //tree.Condition = false;
            worker.clears.Enqueue(tree);
        }
        public void Do()
        {
            //UnityEngine.Debug.Log($"do {this} dele {tree}");
            //if (!Condition)
            worker.dos.Enqueue(tree);
        }

        public bool PreDo()
        {
            if (usePredo)
                worker.dos.Enqueue(tree);
            //tree.PreDo();
            return usePredo;
        }

        public void Apply()
        {
            throw new NotImplementedException();
        }
    }
}
