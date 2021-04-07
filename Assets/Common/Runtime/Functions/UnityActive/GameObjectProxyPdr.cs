using System.Collections.Generic;
using ActionTree;
using UnityEngine;
namespace Default
{
	[System.Serializable]
	public sealed class GameObjectProxy : IComponent
	{
        public GameObject target;
	}
	public class GameObjectProxyPdr: CmpProvider<GameObjectProxy> { }
}
