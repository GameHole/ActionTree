using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ActionTree
{
    public class Mgr : MonoBehaviour
    {
        internal static Queue<TreeProvider> releases = new Queue<TreeProvider>();
        internal readonly static Driver driver = new Driver();
        static Queue<int> removed = new Queue<int>();
        static List<UnityEntity> unityEntities = new List<UnityEntity>();

        public static void AddEntity(UnityEntity unity)
        {
            //Debug.Log(unityEntities.Count);
            driver.AddEntity(unity.tree);
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
            DontDestroyOnLoad(gameObject);
            driver.Init();
            driver.useMulThread = useMulThread;
        }
        void Update()
        {
            //Debug.Log("mgr");
            ATree.deltaTime = Time.deltaTime;
            driver.Run();
            doEntity();
        }
        public static void LoadScene(int id)
        {
            for (int i = 0; i < unityEntities.Count; i++)
            {
                //Debug.Log(unityEntities[i].isDestroyed);
                if (unityEntities[i] != null)
                {
                    unityEntities[i].tree.Condition = true;
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
#if UNITY_EDITOR && !RELEASE
                        Debug.Log($"destroy {unityEntities[i]}");
#endif
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
