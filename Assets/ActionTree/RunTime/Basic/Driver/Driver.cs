﻿using System;
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
        public Queue<Action> postMains = new Queue<Action>();
        internal bool useMulThread = true;
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
        public void AddEntity(ITree v)
        {
            int i = idx++;
            if (v is ETree e)
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
        }
        internal object FindFirstCmp(Type type)
        {
            for (int i = 0; i < workers.Length; i++)
            {
                for (int j = 0; j < workers[i].trees.Count; j++)
                {
                    if (workers[i].trees[j] is ETree eTree)
                    {
                        var cmp = eTree.Get(type);
                        if (cmp != null)
                        {
                            return cmp;
                        }
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
        public List<T> Find<T>() where T : class, IComponent
        {
            var type = typeof(T);
            var ret = new List<T>();
            for (int i = 0; i < workers.Length; i++)
            {
                for (int j = 0; j < workers[i].trees.Count; j++)
                {
                    if (workers[i].trees[j] is ETree eTree)
                    {
                        var cmp = eTree.Get(type);
                        if (cmp != null)
                        {
                            ret.Add((T)cmp);
                        }
                    }
                }
            }
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
        }
    }
}
