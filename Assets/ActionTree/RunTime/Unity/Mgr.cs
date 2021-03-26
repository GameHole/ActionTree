using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ActionTree
{
    public class Mgr : MonoBehaviour
    {
        internal static System.Collections.Generic.Queue<TreeProvider> releases = new System.Collections.Generic.Queue<TreeProvider>();
        internal readonly static Driver driver = new Driver();
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
