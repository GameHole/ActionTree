using ActionTree;
using UnityEngine;
namespace ActionTree
{
    [MainThread(UpdateType.LateUpdate)]
    public sealed class SyncWorldToScreen:ATree
	{
        Position position;
        CameraProxy camera;
        UnityEntity ue;
		public override void Do()
        {
            //Mgr.lateUpdate.Enqueue(_Do);
            ue.transform.position = camera.value.WorldToScreenPoint(position.value);
            Condition = true;
        }
        //void _Do()
        //{
        //    ue.transform.position = camera.value.WorldToScreenPoint(position.value);
        //}
	}
	public class SyncWorldToScreenLeaf : TreeProvider<SyncWorldToScreen> { }
}
