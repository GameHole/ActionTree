using ActionTree;
using UnityEngine;
namespace ActionTree
{
    [MainThread]
	public sealed class DestroyGameObject:ATree
	{
        GameObjectProxy proxy;
		public override void Do()
        {
            Object.Destroy(proxy.target);
            Condition = true;
        }
	}
	public class DestroyGameObjectLeaf : TreeProvider<DestroyGameObject> { }
}
