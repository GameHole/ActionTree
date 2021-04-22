using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace ActionTree
{
    public class Mgr : MonoBehaviour
    {
        internal static Queue<TreeProvider> releases = new Queue<TreeProvider>();
        internal readonly static Driver driver = new Driver();
        static Queue<int> removed = new Queue<int>();
        static List<UnityEntity> unityEntities = new List<UnityEntity>();
        static bool isInited;
        static readonly Entity global = new Entity();
        public static void AddEntity(UnityEntity unity)
        {
            //Debug.Log($"add {unity}");
            driver.AddEntity(unity.tree);
            if (unity.entity != null)
                unity.entity.parent = global;
            if (removed.Count > 0)
            {
                int idx = removed.Dequeue();
                if (unityEntities[idx] != null)
                    throw new System.ArgumentException("you may set a active object");
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
            if (isInited)
            {
                Destroy(gameObject);
                return;
            }
            isInited = true;
            DontDestroyOnLoad(gameObject);
            driver.Init();
            driver.useMulThread = useMulThread;
            LoadGlobal();
        }
        void LoadGlobal()
        {
            var cmps = GetComponentsInChildren<CmpProvider>();
            for (int i = 0; i < cmps.Length; i++)
            {
                global.Add(cmps[i].GetValue());
            }
        }
        void Update()
        {
            //Debug.Log("mgr");
            ATree.deltaTime = Time.deltaTime;
            driver.Run();
            doEntity();
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
                        Debug.Log($"destroy {unityEntities[i]}");
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
                    if (!s.GetComponent<UnityEntity>())
                    {
                        Destroy(s.gameObject);
                    }
                    else
                    {
                        Destroy(s);
                    }
                }
                catch (System.NullReferenceException e)
                {
                    throw new System.NullReferenceException("This error may cause by 'Destroy Order' error ,May be you destroy parent gameobject early than child gameobject",e);
                }
            }
        }
        private void OnDestroy()
        {
            driver.Destroy();
        }
    }
}
