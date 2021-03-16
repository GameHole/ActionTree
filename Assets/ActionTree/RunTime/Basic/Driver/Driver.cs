using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Text;
using System.Reflection;
namespace ActionTree
{
    public class Driver
    {
        int idx = 0;
        Worker[] workers = new Worker[Environment.ProcessorCount - 1];
        public void Init()
        {
            for (int i = 0; i < workers.Length; i++)
            {
                workers[i] = new Worker();
            }
        }
        public void Run()
        {
            if (!isWorking())
            {
                RunMainDo();
                Do();
            }

        }
        void Do()
        {
            for (int i = 0; i < workers.Length; i++)
            {
                workers[i].Start();
            }
        }
        bool isWorking()
        {
            for (int i = 0; i < workers.Length; i++)
            {
                if (workers[i].isRun)
                {
                    return true;
                }
            }
            return false;
        }
        void RunMainDo()
        {
            //UnityEngine.Debug.Log("run main");
            for (int i = 0; i < workers.Length; i++)
            {
                var queue = workers[i].dos;
                while (queue.Count > 0)
                {
                    queue.Dequeue().Do();
                }
            }
            for (int i = 0; i < workers.Length; i++)
            {
                var queue = workers[i].clears;
                while (queue.Count > 0)
                {
                    queue.Dequeue().Clear();
                }
            }
        }
        void Do(List<ITree> runs, List<ITree> removed, int start, int end)
        {
            removed.Clear();
            for (int i = start; i < end; i++)
            {
                if (!runs[i].Condition)
                {
                    runs[i].Do();
                }
                else
                {
                    removed.Add(runs[i]);
                }
            }
        }
        public void AddEntity(Entity v)
        {
            //if (!v.isActive) return;
            if (v.tree != null)
            {
                var worker = workers[idx++ % workers.Length];
                RepleaseTree(ref v.tree, worker);
                //entities.Add(v.tree);
                v.tree.PreDo();
                worker.added.Add(v.tree);
            }
        }
        void RepleaseTree(ref ITree tree, Worker worker)
        {
            if (tree is ATreeCntr treeCntr)
            {
                for (int i = 0; i < treeCntr.trees.Length; i++)
                {
                    RepleaseTree(ref treeCntr.trees[i], worker);
                }
            }
            else
            {
                var main = tree.GetType().GetCustomAttribute<MainThreadAttribute>();
                if (main != null)
                {
                    var proxy = new ProxyTree() { tree = tree, worker = worker };
                    tree = proxy;
                }
            }
        }
        public void Destroy()
        {
            for (int i = 0; i < workers.Length; i++)
            {
                workers[i].Stop();
            }
        }
    }
}
