using ActionTree;
using UnityEngine;
namespace ActionTree
{
    [MainThread(UpdateType.LateUpdate)]
	public sealed class SyncCameraRotation:ATree
	{
        Rotation rotation;
        UnityEntity ue;
        //public Quaternion quaternion => rotation.value;
        //public Transform transform => ue.transform;
		public override void Do()
        {
            if (ue)
                ue.transform.rotation = rotation.value;
            //this.Log("run");
            //Mgr.lateUpdate.Enqueue(_do);
            Condition = true;
        }
        //void _do()
        //{
        //    if (ue)
        //        ue.transform.rotation = rotation.value;
        //}
	}
	public class SyncCameraRotationLeaf: TreeProvider<SyncCameraRotation>
    {
        //public override void DestroySelf() { }
        //private void LateUpdate()
        //{
        //    value.transform.rotation = value.quaternion;
        //}
    }
}
