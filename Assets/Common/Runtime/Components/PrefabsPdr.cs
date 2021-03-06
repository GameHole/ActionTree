using System.Collections.Generic;
using ActionTree;
using UnityEngine;
namespace ActionTree
{
	[System.Serializable]
	public sealed class Prefabs : IComponent
	{
        public GameObject[] prefabs;
        public GameObject this[int index]
        {
            get => prefabs[index];
        }
	}
	public class PrefabsPdr: CmpProvider<Prefabs> { }
}
