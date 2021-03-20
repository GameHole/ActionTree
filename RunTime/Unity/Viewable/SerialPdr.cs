using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ActionTree
{
    public class SerialPdr : TreeCntrProvider<Serial>
    {
#if UNITY_EDITOR &&!RELEASE
        public int index;
        private void Update()
        {
            index = value.index;
        }
#endif
    }
}

