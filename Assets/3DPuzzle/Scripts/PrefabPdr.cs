using System.Collections.Generic;
using ActionTree;
using UnityEngine;
namespace Default
{
	[System.Serializable]
	public sealed class Prefab : IComponent
	{
        public GameObject prefab;
	}
	public class PrefabPdr: CmpProvider<Prefab> { }
}
