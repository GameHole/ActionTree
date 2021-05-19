using ActionTree;
using UnityEngine;
namespace ActionTree
{
    [MainThread]
	public sealed class IsGameObjectActive:ATree
	{
        GameObjectProxy proxy;
		public override void Do()
        {
            Condition = proxy.target.activeInHierarchy;
        }
	}
	public class IsGameObjectActiveLeaf: TreeProvider<IsGameObjectActive> { }
}
