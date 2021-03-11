using System.Collections;
using System.Collections.Generic;
using System;
using System.Threading;
namespace ActionTree
{
    public class MyThread : IThread
    {
        public Action action { get; set; }
        ManualResetEvent manual = new ManualResetEvent(false);
        Thread thread;
        bool isRun;
        public MyThread()
        {
            isRun = true;
            thread = new Thread(() =>
            {
                while (isRun)
                {
                    manual.WaitOne();
                    action?.Invoke();
                    manual.Reset();
                }
                manual.Dispose();
            });
            thread.IsBackground = true;
            thread.Start();
        }
        public void Start()
        {
            if (isRun)
                manual.Set();
        }
        public void Pause()
        {
            if (isRun)
                manual.Reset();
        }
        public void Stop()
        {
            manual.Set();
            isRun = false;
        }
    }
}
