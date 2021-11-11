using ActionTree;
using UnityEngine;
namespace ActionTree
{
    [MainThread]
	public sealed class FindChild:ATree
	{
        GameObjectProxy proxy;
        StringValue childName;
		public override void Do()
        {
            var child= proxy.target.transform.Find(childName);
            if (child)
            {
                proxy.target = child.gameObject;
                Condition = true;
            }
        }
	}
	public class FindChildLeaf: TreeProvider<FindChild> { }
}
