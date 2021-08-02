using ActionTree;
using UnityEngine;
namespace ActionTree
{
    [MainThread]
	public sealed class SyncToTargetLocalPosition:ATree
	{
        GameObjectProxy target;
        Position position;
		public override void Do()
        {
            if (target.target)
                target.target.transform.localPosition = position.value;
            Condition = true;
        }
	}
	public class SyncToTargetLocalPositionLeaf: TreeProvider<SyncToTargetLocalPosition> { }
}
