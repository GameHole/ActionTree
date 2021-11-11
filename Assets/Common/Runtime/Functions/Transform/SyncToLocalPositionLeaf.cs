 using ActionTree;
using UnityEngine;
namespace ActionTree
{
    [MainThread]
	public sealed class SyncToLocalPosition:ATree
	{
        Position position;
        GameObjectProxy target;
		public override void Do()
        {
            if (target.target)
                target.target.transform.localPosition = position.value;
            //this.Log($"p ");
            Condition = true;
        }
	}
	public class SyncToLocalPositionLeaf: TreeProvider<SyncToLocalPosition> { }
}
