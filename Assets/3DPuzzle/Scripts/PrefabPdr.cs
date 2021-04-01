using System.Collections.Generic;
using ActionTree;
using UnityEngine;
namespace ActionTree
{
	[System.Serializable]
	public sealed class Prefab : IComponent
	{
        public GameObject prefab;
	}
	public class PrefabPdr: CmpProvider<Prefab> { }
}
