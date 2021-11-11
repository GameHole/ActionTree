using ActionTree;
using UnityEngine;
namespace ActionTree
{
    [MainThread(UpdateType.LateUpdate)]
    public sealed class SyncTargetWorldToScreen:ATree
	{
        Position position;
        CameraProxy camera;
        GameObjectProxy ue;
        public override void Do()
        {
            ue.target.transform.position = camera.value.WorldToScreenPoint(position.value);
            Condition = true;
        }
	}
	public class SyncTargetWorldToScreenLeaf: TreeProvider<SyncTargetWorldToScreen> { }
}
