using ActionTree;
using UnityEngine;
namespace ActionTree
{
    [MainThread(UpdateType.LateUpdate)]
    public sealed class SyncTargetCameraRotation:ATree
	{
        GameObjectProxy target;
        Rotation position;
        public override void Do()
        {
            target.target.transform.localRotation = position.value;
            Condition = true;
        }
	}
	public class SyncTargetCameraRotationLeaf: TreeProvider<SyncTargetCameraRotation> { }
}
