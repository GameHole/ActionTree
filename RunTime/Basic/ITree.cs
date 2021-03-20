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
    public static class ITreeEx
    {
        public static void TryDo(this ITree tree)
        {
            if (!tree.Condition)
                tree.Do();
        }
    }
}
