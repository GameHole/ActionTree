using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ActionTree
{
    public class UnityEntity : MonoBehaviour,IComponent
    {
        public Entity entity;
        //Entity parentCatche;
        internal ITree tree;
        public bool Condition
        {
            get
            {
                if (tree != null)
                    return tree.Condition;
                return true;
            }
            set
            {
                if (tree != null)
                    tree.Condition = value;
            }
        }
        bool isInited;
        public bool notDestroyOnLoad;
        public virtual bool alwaysRun { get => false; }
        UnityEntity[] childs;
        //Action onDestroyAct;
        private void Awake()
        {
            if (notDestroyOnLoad)
            {
                if (transform.parent == null)
                    DontDestroyOnLoad(gameObject);
            }
            var es = GetComponentsInChildren<UnityEntity>();
            for (int i = 0; i < es.Length; i++)
            {

                if (es[i] != this)
                {
                    es[i].enabled = false;
                    if (es[i].notDestroyOnLoad) continue;
                    es[i].notDestroyOnLoad = notDestroyOnLoad;
                    //Debug.Log($"disable entity child {es[i]} this,{this}");
                }
            }
            childs = es;
            //if (notDestroyOnLoad)
            //    DontDestroyOnLoad(gameObject);
        }
        //internal bool isDestroyed;
        void Start()
        {
            InitOnce();
            var es = childs;
            if (es != null)
            {
                for (int i = 0; i < es.Length; i++)
                {
                    if (es[i] != this && es[i] != null)
                    {
                        es[i].enabled = es[i].alwaysRun;
                    }
                    //Debug.Log($"enable entity child {es[i]} this,{this}");
                }
                childs = null;
            }
        }
        //public Entity TryGetEntity()
        //{
        //    Entity entity = null;
        //    var cmp = GetComponent<CmpProvider>();
        //    if (!cmp)
        //    {
        //        entity = new Entity();
        //        entity.AddImpl<UnityEntity>(this);
        //    }
        //    return entity;
        //}
        /// <summary>
        /// 如果本物体在 隐藏 时调用初始化会出现找不到组件问题
        /// </summary>
        /// <param name="parnet"></param>
        public void InitOnce(Entity parnet=null)
        {
            //Debug.Log($"init pdr this::{this} parent::{parnet}");
            //Debug.Log($"init {this}");
            if (isInited) return;
            isInited = true;
            //if (parnet == null)
            //{
            //    parnet = TryGetEntity();
            //}
            entity = new Entity();
            entity.parent = parnet;
            entity.AddImpl<UnityEntity>(this);
            MakeEntity(entity);
            var pdr = GetComponent<TreeProvider>();
            if (pdr)
            {
                //Debug.Log($"init pdr this::{this} parent::{parnet}");
                //this.parentCatche = parnet;
                pdr.MakeEntity(entity);
                //Debug.Log($"{this} {entity}" );
                pdr.CollectComponent();
                //if (entity != null)
                //    entity.parent = parnet;
                tree = pdr.GetTree();
                //Debug.Log($"{this} {tree} c::{tree.Condition}");
                if (tree != null)
                {
                    tree.Apply();
                }
                Join();
            }
            //else
            //{
            //    //Debug.Log($"init e {this}");
            //    MakeEntity(entity);
            //}
            //Debug.Log($"e::{entity} parent::{parnet}");
            //if (entity != parnet)
            //{
            //    Mgr.driver.AddEntity(entity);
            //}
            Mgr.driver.AddEntity(entity);
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
                Mgr.AddTree(this);
        }

        public void MakeEntity(Entity e)
        {
            var cmps = GetComponents<CmpProvider>();
            if (cmps.Length > 0)
            {
                //entity = new Entity();
                for (int i = 0; i < cmps.Length; i++)
                {
                    entity.Add(cmps[i].GetValue());
                }
                //entity.Add(this);
                //entity.parent = e;
                //if (e != null)
                //{
                //    e.childs.Add(entity);
                //}
            }
            //else
            //{
            //    entity = e;
            //}
        }
        private void OnDestroy()
        {

            if (entity != null)
            {
                Mgr.driver.RemoveEntity(entity);
                //string a = "";
                //foreach (var item in entity.components.Keys)
                //{
                //    a += item.ToString() + ",";
                //}
                //Debug.Log($"OnDestroy {this} {entity.id} {entity.GetCmpHash()} {a}");
            }
            if (tree != null)
            {
                tree.Condition = !notDestroyOnLoad;
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
