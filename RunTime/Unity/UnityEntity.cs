using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ActionTree
{
    public class UnityEntity : MonoBehaviour, IComponent
    {
        //public Entity entity;
        public ETree tree;
        bool isInited;
        void Start()
        {
            InitOnce();
        }
        public void InitOnce()
        {
            if (isInited) return;
            isInited = true;
            var initer = GetComponent<IEntityIniter>();
            initer?.Init(this);
            if (tree != null)
                Mgr.AddEntity(this);
        }
//        internal void _Update()
//        {
//            if (tree != null)
//            {
//                if (tree.Condition)
//                {
//#if UNITY_EDITOR||!RELEASE
//                    Debug.Log($"destroy {this}");
//#endif
//                    Destroy(gameObject);
//                }
//            }
//        }
    }
}
