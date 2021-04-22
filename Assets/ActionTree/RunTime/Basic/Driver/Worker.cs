//#define DEBUG_TIME
using System;
using System.Collections.Generic;
using System.Text;

namespace ActionTree
{
    class Worker
    {
        IThread thread = new MyThread2();
        public bool isRun;
        public List<ITree> trees = new List<ITree>();
        public List<ITree> added = new List<ITree>();
        public List<ITree> removed = new List<ITree>();
        public Queue<ITree> dos = new Queue<ITree>();
        public Queue<ITree> clears = new Queue<ITree>();
#if DEBUG_TIME
        long add = 0;
        long count;
        System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
#endif
        public Worker()
        {
            thread.action = Run;
        }
        public void Run()
        {
#if DEBUG_TIME
            stopwatch.Restart();
#endif
            Remove();
            Add();
            Do(trees, removed);
            isRun = false;
#if DEBUG_TIME
            stopwatch.Stop();
            count++;
            add += stopwatch.ElapsedTicks;
            if (count >= 20)
            {
                count = 0;
                long e = add / 20;
                add = 0;
                UnityEngine.Debug.Log($"thread {e} ticks {(double)e / 1e4} ms");
            }
#endif
        }
        void Do(List<ITree> runs,List<ITree> removed)
        {
            //UnityEngine.Debug.Log($"removed clear");
            removed.Clear();
            for (int i = 0; i < runs.Count; i++)
            {
                if (!runs[i].Condition)
                {
                    runs[i].Do();
                    //UnityEngine.Debug.Log($"run {runs[i]}");
                }
                else
                {
                    removed.Add(runs[i]);
                    //UnityEngine.Debug.Log($"removed {runs[i]}");
                }
            }
        }
        void Add()
        {
            if (added.Count > 0)
            {
                trees.AddRange(added);
                //foreach (var item in added)
                //{
                //    UnityEngine.Debug.Log($"add {item}");
                //}
                added.Clear();
            }
        }
        void Remove()
        {
            for (int i = 0; i < removed.Count; i++)
            {
                trees.Remove(removed[i]);
            }
            removed.Clear();
        }
        public void Start()
        {
            isRun = true;
            thread.Start();
        }
        public void Stop()
        {
            thread.Stop();
        }
    }
}
