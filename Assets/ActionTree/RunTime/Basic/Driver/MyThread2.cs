
using System;
using System.Threading;
using System.Diagnostics;

namespace ActionTree
{
    public class MyThread2 :IThread
    {
        public Action action { get; set; }
        Thread thread;
        bool isRun;
        //Stopwatch stopwatch = new Stopwatch();
        public MyThread2()
        {
            isRun = true;
            thread = new Thread(() =>
            {
                while (isRun)
                {
                    try
                    {
                        action?.Invoke();
                        Thread.Sleep(Timeout.Infinite);
                    }
                    catch (ThreadInterruptedException)
                    {
                    }
                }
            });
            thread.IsBackground = true;
            thread.Start();
        }
        public void Start()
        {
            //stopwatch.Restart();
            thread.Interrupt();
            //stopwatch.Stop();
            //UnityEngine.Debug.Log($"MyThread2 start used::{stopwatch.Elapsed.TotalMilliseconds}");
        }
        public void Stop()
        {
            isRun = false;
            thread.Interrupt();
        }
    }
}

