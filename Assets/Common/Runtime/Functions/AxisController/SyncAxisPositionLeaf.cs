using ActionTree;
using UnityEngine;
namespace ActionTree
{
	public sealed class SyncAxisPosition:ATree
	{
        Position position;
        Vector2Value direction;
        FloatValue r;
		public override void Do()
        {
            position.value = direction.value * r;
            Condition = true;
        }
	}
	public class SyncAxisPositionLeaf: TreeProvider<SyncAxisPosition> { }
}
