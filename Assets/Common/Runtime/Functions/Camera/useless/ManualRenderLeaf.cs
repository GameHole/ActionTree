using ActionTree;
using UnityEngine;
namespace ActionTree
{
    [MainThread]
	public sealed class ManualRender:ATree
	{
        CameraProxy proxy;
		public override void Do()
        {
            proxy.value.enabled = false;
            proxy.value.Render();
            Condition = true;
        }
	}
	public class ManualRenderLeaf: TreeProvider<ManualRender> { }
}
