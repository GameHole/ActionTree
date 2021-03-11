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
        public Entity Entity { get; set; }
        public bool Condition => tree.Condition;
        public Worker worker;
        public void Clear()
        {
            worker.clears.Enqueue(tree);
        }
        public void Do()
        {
            //Driver.doQueue.Enqueue(tree);
        }

        public void PreDo()
        {
           worker.dos.Enqueue(tree);
        }
    }
}
