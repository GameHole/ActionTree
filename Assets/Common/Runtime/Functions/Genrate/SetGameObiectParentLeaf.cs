using ActionTree;
using UnityEngine;
namespace ActionTree
{
    [MainThread]
	public sealed class SetGameObiectParent:ATree
	{
        UnityParent uparent;
        GameObjectProxy proxy;
		public override void Do()
        {
            proxy.target.transform.SetParent(uparent.value);
            Condition = true;
        }
	}
	public class SetGameObiectParentLeaf: TreeProvider<SetGameObiectParent> { }
}
