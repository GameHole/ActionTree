using ActionTree;
using UnityEngine;
namespace Default
{
	[System.Serializable]
	public sealed class CubePrefab : IComponent
	{
        public Id prefabs;
        [HideInInspector]public Id[] uis;
	}
	public class CubePrefabPdr: CmpProvider<CubePrefab> { }
}
