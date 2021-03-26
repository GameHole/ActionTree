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
                Mgr.driver.AddEntity(tree);
        }
        private void Update()
        {
            if (tree != null)
            {
                if (tree.Condition)
                {
                    Debug.Log($"destroy {this}");
                    Destroy(gameObject);
                }
            }
        }
    }
}
