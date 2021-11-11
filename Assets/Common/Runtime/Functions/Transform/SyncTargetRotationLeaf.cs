using ActionTree;
using UnityEngine;
namespace ActionTree
{
    [MainThread]
	public sealed class SyncTargetRotation:ATree
	{
        Rotation rotation;
        GameObjectProxy target;
		public override void Do()
        {
            target.target.transform.rotation = rotation.value;
            Condition = true;
        }
	}
	public class SyncTargetRotationLeaf: TreeProvider<SyncTargetRotation> { }
}
