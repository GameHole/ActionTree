using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ActionTree
{
    public class Mgr : MonoBehaviour
    {
        internal static Queue<TreeProvider> releases = new Queue<TreeProvider>();
        internal readonly static Driver driver = new Driver();
        static Stack<int> unused = new Stack<int>();
        static List<UnityEntity> unityEntities = new List<UnityEntity>();
        public static void AddEntity(UnityEntity unity)
        {
            //Debug.Log(unityEntities.Count);
            driver.AddEntity(unity.tree);
            if (unused.Count > 0)
            {
                unityEntities[unused.Pop()] = unity;
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
        void doEntity()
        {
            for (int i = 0; i < unityEntities.Count; i++)
            {
                if (unityEntities[i] != null)
                {
                    unityEntities[i]._Update();
                }
                else
                {
                    unused.Push(i);
                    unityEntities[i] = null;//释放mono引用
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
