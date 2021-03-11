using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ActionTree
{
    public class UnityEntity : MonoBehaviour,IComponent
    {
        public Entity entity;
        bool isInited;
        void Start()
        {
            Init();
        }
        public void Init()
        {
            if (isInited) return;
            isInited = true;
            var initer = GetComponent<IEntityIniter>();
            initer?.Init(this);
            if (entity != null)
                Mgr.driver.AddEntity(entity);
        }
        private void Update()
        {
            if (entity != null)
            {
                //Debug.Log("en");
                ////Debug.Log(entity.isActive);
                //Debug.Log(entity.tree.Condition);
                if (entity.tree.Condition)
                    Destroy(gameObject);
            }
        }
    }
}
