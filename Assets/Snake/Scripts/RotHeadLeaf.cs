using ActionTree;
using UnityEngine;
namespace ActionTree
{
	public sealed class RotHead:ATree
	{
        Direction direction;
        Rotation rotation;
		public override void Do()
        {
            if (direction.value != Vector3.zero)
                rotation.value = Quaternion.LookRotation(direction.value);
            Condition = true;
        }
	}
	public class RotHeadLeaf: TreeProvider<RotHead> { }
}
