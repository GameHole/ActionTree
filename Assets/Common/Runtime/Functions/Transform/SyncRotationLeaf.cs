using ActionTree;
using UnityEngine;
namespace ActionTree
{
	[MainThread]
	public sealed class SyncRotation:ATree
	{
        Rotation rotation;
        UnityEntity entity;
		public override void Do()
        {
            entity.transform.rotation = rotation.value;
           
            Condition = true;
        }
	}
	public class SyncRotationLeaf: TreeProvider<SyncRotation> { }
}
