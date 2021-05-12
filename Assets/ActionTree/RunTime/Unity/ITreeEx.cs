using System.Collections.Generic;
using UnityEngine;
namespace ActionTree
{
    public static partial class ITreeEx
    {
        public static void Log(this ITree tree, object v)
        {
            Debug.Log(tree.debug(v));
        }
        public static void Error(this ITree tree, object v)
        {
            Debug.LogError(tree.debug(v));
        }
        public static void Warning(this ITree tree, object v)
        {
            Debug.LogWarning(tree.debug(v));
        }
    }
}
