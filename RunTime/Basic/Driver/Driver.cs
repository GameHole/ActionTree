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
        EntityCntr cntr = new EntityCntr();
        //Dictionary<ITree, Entity> es = new Dictionary<ITree, Entity>();
        public Queue<Action> postMains = new Queue<Action>();
        //Queue<ITree> removed = new Queue<ITree>();
        internal bool useMulThread = true;
        public void Init()
        {
            //UnityEngine.Debug.Log("Init");
            for (int i = 0; i < workers.Length; i++)
            {
                workers[i] = new Worker();
            }
        }
        //internal void onRemove(ITree tree)
        //{
        //    lock (removed)
        //    {
        //        removed.Enqueue(tree);
        //    }
        //}
        public void Run()
        {
            if (!isWorking())
            {
                RunMainDo();
                PostMain();
                Do();
            }

        }
        void PostMain()
        {
            while (postMains.Count > 0)
            {
                postMains.Dequeue()?.Invoke();
            }
        }
        void Do()
        {
            if (useMulThread)
            {
                for (int i = 0; i < workers.Length; i++)
                {
                    workers[i].Start();
                }
            }
            else
            {
                for (int i = 0; i < workers.Length; i++)
                {
                    workers[i].Run();
                }
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
        //void RemoveEntity(ITree tree)
        //{
        //    if(es.TryGetValue(tree,out var m))
        //    {
        //        UnityEngine.Debug.Log($"remove e{m.id}");
        //        cntr.Remove(m);
        //    }
        //}
        void RunMainDo()
        {
            for (int i = 0; i < workers.Length; i++)
            {
                var queue = workers[i].clears;
                while (queue.Count > 0)
                {
                    queue.Dequeue().Clear();
                }
            }
            //while (removed.Count > 0)
            //{
            //    var e = removed.Dequeue().entity;
            //    if (e != null)
            //    {
            //        var p = e;
            //        while (p != null)
            //        {
            //            cntr.Remove(p);
            //            p = p.parent;
            //        }
            //    }
            //}
            //UnityEngine.Debug.Log("run main");
            for (int i = 0; i < workers.Length; i++)
            {
                var queue = workers[i].dos;
                while (queue.Count > 0)
                {
                    queue.Dequeue().Do();
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
        public void AddEntity(Entity entity)
        {
            cntr.Add(entity);
        }
        public void RemoveEntity(Entity entity)
        {
            cntr.Remove(entity);
        }
        public void AddTree(ITree v)
        {
            //UnityEngine.Debug.Log($"dr add {v.entity.Get<UnityEntity>()}");
            int i = idx++;
            var e = v.entity;
            if (e != null)
            {
                var tid = e.Get<ThreadId>();
                if (tid != null)
                {
                    i = tid.value;
                    e.Remove<ThreadId>();
                }
            }
            var worker = workers[i % workers.Length];
            v.Foreach((ref ITree x) =>
            {
                if (x is ATree aTree)
                    aTree.driver = this;
            });
            RepleaseTree(ref v, worker);
            v.PreDo();
            worker.added.Add(v);
            //UnityEngine.Debug.Log("driver add");
        }
        internal IComponent FindFirstCmp(Type type)
        {
            //for (int i = 0; i < workers.Length; i++)
            //{
            //    for (int j = 0; j < workers[i].trees.Count; j++)
            //    {
            //        var e = workers[i].trees[j].entity;
            //        if (e != null)
            //        {
            //            var cmp = e.FindComponent(type);
            //            if (cmp != null)
            //            {
            //                return cmp;
            //            }
            //        }
            //    }
            //}
            //return null;
            var ls = cntr.Find(type);
            if (ls.Count > 0)
            {
                //UnityEngine.Debug.Log($"firet  eid {ls[0].id}");
                return ls[0].Get(type);
            }
            return null;
        }
        internal Entity FindEntityWith(params Type[] type)
        {
            //for (int i = 0; i < workers.Length; i++)
            //{
            //    for (int j = 0; j < workers[i].trees.Count; j++)
            //    {
            //        var e = workers[i].trees[j].entity;
            //        if (e != null)
            //        {
            //            if (e.ContainAll(type))
            //            {
            //                return e;
            //            }
            //        }
            //    }
            //}
            //return null;
            var ls = cntr.Find(type);
            if (ls.Count > 0)
                return ls[0];
            return null;
        }
        public IList<Entity> FindEntitysWith(params Type[] type)
        {
            //var ret = new List<Entity>();
            //for (int i = 0; i < workers.Length; i++)
            //{
            //    for (int j = 0; j < workers[i].trees.Count; j++)
            //    {
            //        var e = workers[i].trees[j].entity;
            //        if (e != null)
            //        {
            //            if (e.ContainAll(type))
            //            {
            //                ret.Add(e);
            //            }
            //        }
            //    }
            //}
            //return ret;
            return cntr.Find(type);
        }
        public Entity FindEntityWith<T>() where T : class, IComponent
        {
            return FindEntityWith(typeof(T));
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
        public List<T> Find<T>() where T : class, IComponent
        {
            var type = typeof(T);
            var ret = new List<T>();
            var es = cntr.Find(type);
            for (int i = 0; i < es.Count; i++)
            {
                ret.Add(es[i].Get<T>());
            }
            //for (int i = 0; i < workers.Length; i++)
            //{
            //    for (int j = 0; j < workers[i].trees.Count; j++)
            //    {
            //        var e = workers[i].trees[j].entity;
            //        if (e != null)
            //        {
            //            var cmp = e.Get(type);
            //            if (cmp != null)
            //            {
            //                ret.Add((T)cmp);
            //            }
            //        }
            //    }
            //}
            return ret;
        }
        void RepleaseTree(ref ITree tree, Worker worker)
        {
            if (tree is ATreeCntr treeCntr)
            {
                for (int i = 0; i < treeCntr.Count; i++)
                {
                    RepleaseTree(ref treeCntr.trees[i], worker);
                }
            }
            else
            {
                var t = tree.GetType();
                var main = t.GetCustomAttribute<MainThreadAttribute>();
                if (main != null)
                {
                    var predo = t.GetCustomAttribute<NotPreDoAttribute>();
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
            cntr.Clear();
            //es.Clear();
            //removed.Clear();
        }
    }
}
