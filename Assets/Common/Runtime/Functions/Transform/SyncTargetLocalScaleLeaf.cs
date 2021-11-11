using ActionTree;
using UnityEngine;
namespace Washer
{
    [MainThread]
	public sealed class SyncTargetLocalScale:ATree
	{
        Vector3Value scale;
        GameObjectProxy go;
		public override void Do()
        {
            go.target.transform.localScale = scale;
            Condition = true;
        }
	}
	public class SyncTargetLocalScaleLeaf: TreeProvider<SyncTargetLocalScale> { }
}
