using ActionTree;
using UnityEngine;
namespace ActionTree
{
    [MainThread(UpdateType.LateUpdate)]
	public sealed class SyncTargetCameraPosition : ATree
	{
        GameObjectProxy target;
        Position position;
        public override void Do()
        {
            //Mgr.lateUpdate.Enqueue(_Do);
            target.target.transform.localPosition = position.value;
            Condition = true;
        }
        //void _Do()
        //{
        //    target.target.transform.localPosition = position.value;
        //}
    }
	public class SyncTargetCameraPositionLeaf : TreeProvider<SyncTargetCameraPosition> { }
}
