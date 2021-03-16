using System.Collections.Generic;
using ActionTree;
using UnityEngine;
namespace Default
{
	[System.Serializable]
	public sealed class CombinedUICntr : IComponent
	{
        public GameObject item;
        public Transform parent;
        [HideInInspector] public List<GameObject> items = new List<GameObject>();
        [HideInInspector] public List<Click> clicks = new List<Click>();
    }
	public class CombinedUICntrPdr: CmpProvider<CombinedUICntr> { }
}
