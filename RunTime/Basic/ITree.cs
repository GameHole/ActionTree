using System;
using System.Collections.Generic;
using System.Text;

namespace ActionTree
{
    public interface ITree
    {
        Entity Entity { get; set; }
        bool Condition { get; }
        void Do();
        bool PreDo();
        void Clear();
    }
}
