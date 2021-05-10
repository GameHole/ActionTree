﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.Events;

namespace ActionTree
{
    public class UnityWorker
    {
        public Queue<ITree> dos = new Queue<ITree>();
        public Queue<ITree> clears = new Queue<ITree>();
    }
    public class Mgr : MonoBehaviour
    {
        internal static Queue<TreeProvider> releases = new Queue<TreeProvider>();
        internal readonly static Driver driver = new Driver();
        internal static UnityWorker[] workers;
        public static Queue<Action> postMains = new Queue<Action>();
        static Queue<int> removed = new Queue<int>();
        static List<UnityEntity> unityEntities = new List<UnityEntity>();
        public static void AddTree(UnityEntity unity)
        {
            //Debug.Log($"add {unity}");
            driver.AddTree(unity.tree);
            if (removed.Count > 0)
            {
                int idx = removed.Dequeue();
                if (unityEntities[idx] != null)
                    throw new ArgumentException("you may set a active object");
                unityEntities[idx] = unity;
            }
            else
            {
                unityEntities.Add(unity);
            }
        }
        public bool useMulThread = true;
        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
            driver.Init();
            driver.onBeforeRun += RunMainDo;
            driver.onBeforeRun += PostMain;
            InitWorkers();
            driver.onTreeAdded.Insert(0, RepleaseProxyTree);
            driver.useMulThread = useMulThread;
            foreach (var item in GetComponentsInChildren<UnityEntity>())
            {
                item.notDestroyOnLoad = true;
            }
        }
        void InitWorkers()
        {
            workers = new UnityWorker[driver.Workers.Length];
            for (int i = 0; i < workers.Length; i++)
            {
                workers[i] = new UnityWorker();
            }
        }
        void RepleaseProxyTree(ref ITree tree,int id)
        {
            if (tree is ATreeCntr treeCntr)
            {
                for (int i = 0; i < treeCntr.Count; i++)
                {
                    RepleaseProxyTree(ref treeCntr.trees[i], id);
                }
            }
            else
            {
                var t = tree.GetType();
                var main = t.GetCustomAttribute<MainThreadAttribute>();
                if (main != null)
                {
                    var predo = t.GetCustomAttribute<NotPreDoAttribute>();
                    var proxy = new ProxyTree() { tree = tree, worker = workers[id], usePredo = predo == null };
                    tree = proxy;
                }
            }
        }
        void Update()
        {
            //Debug.Log("mgr");
            ATree.deltaTime = Time.deltaTime;
            driver.Run();
            doEntity();
        }
        static void PostMain()
        {
            while (postMains.Count > 0)
            {
                postMains.Dequeue()?.Invoke();
            }
        }
        static void RunMainDo()
        {
            for (int i = 0; i < workers.Length; i++)
            {
                var queue = workers[i].clears;
                while (queue.Count > 0)
                {
                    queue.Dequeue().Clear();
                }
            }
            //UnityEngine.Debug.Log("run main");
            for (int i = 0; i < workers.Length; i++)
            {
                var queue = workers[i].dos;
                while (queue.Count > 0)
                {
                    var t = queue.Dequeue();
                    try
                    {
                        t.Do();
                    }
                    catch (Exception e)
                    {
                        throw new Exception(t.stack(), e);
                    }
                }
            }
        }
        public static void LoadScene(int id,UnityAction<UnityEngine.SceneManagement.Scene, UnityEngine.SceneManagement.LoadSceneMode> onLoad = null)
        {
            for (int i = 0; i < unityEntities.Count; i++)
            {
                //Debug.Log(unityEntities[i].isDestroyed);
                var e = unityEntities[i];
                if (e != null)
                {
                    e.tree.Condition = !e.notDestroyOnLoad;
                }
            }
            UnityEngine.SceneManagement.SceneManager.LoadScene(id);
        }
        void doEntity()
        {
            for (int i = 0; i < unityEntities.Count; i++)
            {
                //Debug.Log(unityEntities[i].isDestroyed);
                if (unityEntities[i] != null)
                {
                    if (unityEntities[i].tree.Condition)
                    {
//#if UNITY_EDITOR && !RELEASE
//                        Debug.Log($"destroy {unityEntities[i]}");
//#endif
                        Destroy(unityEntities[i].gameObject);
                        removed.Enqueue(i);
                        //Debug.Log($"enqueue  {i}");
                        unityEntities[i] = null;
                    }
                }
            }
        }
        private void LateUpdate()
        {
            for (int i = 0; i < 100; i++)
            {
                if (releases.Count <= 0)
                {
                    break;
                }
                //Debug.Log(releases.Count);
                var s = releases.Dequeue();
                //Debug.Log(s);
                try
                {
                    if (s)
                    {
                        if (!s.GetComponent<UnityEntity>())
                        {
                            Destroy(s.gameObject);
                        }
                        else
                        {
                            Destroy(s);
                        }
                    }
                }
                catch (System.NullReferenceException)
                {
                   Debug.LogError("This error may cause by 'Destroy Order' error ,May be you destroy parent gameobject early than child gameobject");
                }
            }
        }
        private void OnDestroy()
        {
            driver.Destroy();
        }
    }
}
