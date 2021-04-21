using System.Collections.Generic;
using ActionTree;
using UnityEngine;
namespace ActionTree
{
    [System.Serializable]
    public sealed class GameObjectProxy : IComponent
    {
        public GameObject target;
    }
	public class GameObjectProxyPdr: CmpProvider<GameObjectProxy> { }
}
