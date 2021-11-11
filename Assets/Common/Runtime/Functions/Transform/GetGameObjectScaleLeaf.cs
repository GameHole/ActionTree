using ActionTree;
using UnityEngine;
namespace ActionTree
{
    [MainThread]
	public sealed class GetGameObjectScale:ATree
	{
        GameObjectProxy proxy;
        Scale scale;
		public override void Do()
        {
            scale.value = proxy.target.transform.lossyScale;
            Condition = true;
        }
	}
	public class GetGameObjectScaleLeaf: TreeProvider<GetGameObjectScale> { }
}
