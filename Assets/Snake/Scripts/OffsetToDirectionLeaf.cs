using ActionTree;
using UnityEngine;
namespace ActionTree
{
	public sealed class OffsetToDirection:ATree
	{
        Offset offset;
        Direction direction;
		public override void Do()
        {
            direction.value = offset.value;
        }
	}
	public class OffsetToDirectionLeaf: TreeProvider<OffsetToDirection> { }
}
