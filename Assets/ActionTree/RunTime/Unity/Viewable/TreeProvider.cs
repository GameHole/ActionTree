using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ActionTree
{
    public abstract class TreeProvider : MonoBehaviour
    {
#if UNITY_EDITOR &&!RELEASE
        public bool debugCondition;
#endif
        //public bool isMainThread;
        public abstract ITree tree { get; }
        public abstract ITree GetTree();
#if UNITY_EDITOR &&!RELEASE
        private void Update()
        {
            debugCondition = tree.Condition;
        }
#endif
        public void DestroySelf()
        {
            Mgr.releases.Enqueue(this);
        }
    }
    public abstract class TreeProvider<T> : TreeProvider where T : ATree, new()
    {
        public T value = new T();
        public override ITree tree => value;
        public override ITree GetTree()
        {
#if !UNITY_EDITOR || RELEASE
            DestroySelf();
#endif
            return value;
        }
    }
    public abstract class TreeCntrProvider<T> : TreeProvider where T : ATreeCntr, new()
    {
        protected T value = new T();
        public override ITree tree => value;
        public override ITree GetTree()
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                var child = transform.GetChild(i);
                if (child.gameObject.activeInHierarchy)
                {
                    var item = child.GetComponent<TreeProvider>();
                    if (item)
                        value.Add(item.GetTree());
                }
            }
#if !UNITY_EDITOR || RELEASE
            DestroySelf();
#endif
            return value;
        }
    }
}
