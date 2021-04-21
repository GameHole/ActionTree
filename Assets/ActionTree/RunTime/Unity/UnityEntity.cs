using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ActionTree
{
    public class UnityEntity : MonoBehaviour,IComponent
    {
        public Entity entity;
        internal ITree tree;
        bool isInited;
        private void Awake()
        {
            var es = GetComponentsInChildren<UnityEntity>();
            for (int i = 0; i < es.Length; i++)
            {
                if (es[i] != this)
                    es[i].enabled = false;
            }
        }
        //internal bool isDestroyed;
        void Start()
        {
            InitOnce();
        }
        public void InitOnce(Entity parnet=null)
        {
            if (isInited) return;
            isInited = true;
            //entity = new Entity();
            var pdr = GetComponent<TreeProvider>();
            if (pdr)
            {
                entity = pdr.MakeEntity(parnet);
                //Debug.Log($"{this} {entity}" );
                pdr.CollectComponent();
                //if (entity != null)
                //    entity.parent = parnet;
                tree = pdr.GetTree();
                //Debug.Log($"{this} {tree.Entity}");
                if (tree != null)
                {
                    tree.Apply();
                }
                Join();
            }
            else
            {
                MakeEntity(parnet);
            }
            InitChild();
        }
        void InitChild()
        {
            var es = GetComponentsInChildren<UnityEntity>();
            for (int i = 0; i < es.Length; i++)
            {
                if (es[i] != this)
                    es[i].InitOnce(entity);
            }
        }
        protected virtual void Join()
        {
            if (tree != null)
                Mgr.AddEntity(this);
        }

        public void MakeEntity(Entity e)
        {
            var cmps = GetComponents<CmpProvider>();
            if (cmps.Length > 0)
            {
                entity = new Entity();
                for (int i = 0; i < cmps.Length; i++)
                {
                    entity.Add(cmps[i].GetValue());
                }
                entity.parent = e;
            }
            else
            {
                entity = e;
            }
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
