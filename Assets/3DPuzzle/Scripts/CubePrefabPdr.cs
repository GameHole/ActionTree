using ActionTree;
using UnityEngine;
namespace ActionTree
{
	[System.Serializable]
	public sealed class CubePrefab : IComponent
	{
        public Id prefabs;
        public Transform parent;
        [HideInInspector]public Id[] uis;
	}
	public class CubePrefabPdr: CmpProvider<CubePrefab> { }
}
