using ActionTree;
using UnityEngine;
namespace ActionTree
{
    [MainThread]
	public sealed class GetGameObjectRotation:ATree
	{
        GameObjectProxy proxy;
        Rotation rotation;
		public override void Do()
        {
            rotation.value = proxy.target.transform.rotation;
            Condition = true;
        }
	}
	public class GetGameObjectRotationLeaf: TreeProvider<GetGameObjectRotation> { }
}
