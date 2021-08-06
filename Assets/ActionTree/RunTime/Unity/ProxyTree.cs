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

        public UnityWorker worker;
        public UpdateType updateType;
        public bool usePredo = true;
        public void Clear()
        {
            //tree.Condition = false;
            worker.clears.Enqueue(tree);
        }
        public void Do()
        {
            switch (updateType)
            {
                case UpdateType.Update:
                    worker.dos.Enqueue(tree);
                    break;
                case UpdateType.LateUpdate:
                    Mgr.lateUpdate.Enqueue(tree.Do);
                    break;
            }
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
            tree.Apply();
            //throw new NotImplementedException($"May entity`s  parent entity has 'TreeProvider' component \nRoute:{tree.stack()}");
        }
    }
}
