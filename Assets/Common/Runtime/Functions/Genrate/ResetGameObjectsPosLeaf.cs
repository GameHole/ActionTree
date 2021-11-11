using ActionTree;
using UnityEngine;
namespace Washer
{
    [MainThread]
	public sealed class ResetGameObjectsPos:ATree
	{
        GameObjectCntr cntr;
		public override void Do()
        {
            foreach (var item in cntr)
            {
                item.transform.localPosition = Vector3.zero;
            }
            Condition = true;
        }
	}
	public class ResetGameObjectsPosLeaf: TreeProvider<ResetGameObjectsPos> { }
}
