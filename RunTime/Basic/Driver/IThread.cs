
using System;

namespace ActionTree
{
    public interface IThread
    {
        Action action { set; }
        void Start();
        void Stop();
    }
}

