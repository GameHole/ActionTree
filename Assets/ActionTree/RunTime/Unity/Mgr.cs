using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ActionTree
{
    public class Mgr : MonoBehaviour
    {
        internal static Queue<TreeProvider> releases = new Queue<TreeProvider>();
        internal readonly static Driver driver = new Driver();
        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
            driver.Init();
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
                var s = releases.Dequeue();
                //Debug.Log(s);
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
        private void OnDestroy()
        {
            driver.Destroy();
        }
    }
}
