//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//namespace ActionTree
//{
//    public class DataProvider : MonoBehaviour
//    {
//        private void Awake()
//        {
//            var es = GetComponentsInChildren<UnityEntity>();
//            for (int i = 0; i < es.Length; i++)
//            {
//                es[i].enabled = false;
//            }
//        }
//        private void Start()
//        {
//            CmpProvider[] pdrs = GetComponents<CmpProvider>();
//            IComponent[] components = new IComponent[pdrs.Length];
//            for (int i = 0; i < components.Length; i++)
//            {
//                components[i] = pdrs[i].GetValue();
//            }
//            var es = GetComponentsInChildren<UnityEntity>();
//            for (int i = 0; i < es.Length; i++)
//            {
//                es[i].InitOnce(()=>
//                {
//                    if (es[i].tree != null)
//                    {
//                        for (int m = 0; m < components.Length; m++)
//                        {
//                            es[i].tree.Add(components[m]);
//                        }
//                    }
//                });
//            }
//        }
//    }
//}

