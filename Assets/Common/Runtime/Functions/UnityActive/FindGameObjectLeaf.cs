using ActionTree;
using UnityEngine;
namespace ActionTree
{
    [MainThread]
	public sealed class FindGameObject:ATree
	{
        StringValue name;
        [AllowNull]GameObjectProxy proxy;
		public override void Do()
        {
            var find = GameObject.Find(name.value);
            //this.Log($"name ::{name.value} find::{find}");
            if (find)
            {
                if (proxy != null)
                    proxy.target = find;
                Condition = true;
            }
        }
	}
	public class FindGameObjectLeaf: TreeProvider<FindGameObject> { }
}
