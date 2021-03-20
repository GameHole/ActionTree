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
        //List<Entity> entities = new List<Entity>();
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
                v.SetData(this);
                var worker = workers[idx++ % workers.Length];
                RepleaseTree(ref v.tree, worker);
                //entities.Add(v.tree);
                v.tree.PreDo();
                worker.added.Add(v.tree);
                //entities.Add(v);
            }
        }
        internal object FindFirstCmp(Type type)
        {
            for (int i = 0; i < workers.Length; i++)
            {
                for (int j = 0; j < workers[i].trees.Count; j++)
                {
                    var cmp = workers[i].trees[j].Entity.Get(type);
                    if (cmp != null)
                    {
                        return cmp;
                    }
                }
            }
            return null;
        }
        public T FindFirstCmp<T>()where T:class,IComponent
        {
            return FindFirstCmp(typeof(T)) as T;
        }
        public bool TryFindFirstCmp<T>(ref T v) where T : class, IComponent
        {
            if (v != null)
            {
                return true;
            }
            v = FindFirstCmp(typeof(T)) as T;
            return v != null;
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
                var t = tree.GetType();
                var main =t.GetCustomAttribute<MainThreadAttribute>();
                if (main != null)
                {
                    var predo=t.GetCustomAttribute<NotPreDoAttribute>();
                    var proxy = new ProxyTree() { tree = tree, worker = worker, usePredo = predo == null };
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
