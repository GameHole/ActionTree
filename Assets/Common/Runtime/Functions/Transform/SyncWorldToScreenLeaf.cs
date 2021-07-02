using ActionTree;
using UnityEngine;
namespace ActionTree
{
    //[MainThread]
	public sealed class SyncWorldToScreen:ATree
	{
        Position position;
        CameraProxy camera;
        UnityEntity ue;
		public override void Do()
        {
            Mgr.lateUpdate.Enqueue(_Do);
            
            Condition = true;
        }
        void _Do()
        {
            ue.transform.position = camera.value.WorldToScreenPoint(position.value);
        }
	}
	public class SyncWorldToScreenLeaf : TreeProvider<SyncWorldToScreen> { }
}
