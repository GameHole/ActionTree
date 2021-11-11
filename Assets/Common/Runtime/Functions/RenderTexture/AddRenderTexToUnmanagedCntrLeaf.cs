using ActionTree;
using UnityEngine;
namespace ActionTree
{
	public sealed class AddRenderTexToUnmanagedCntr:ATree
    {
        RenderTexProxy proxy;
        UnmanagedCntr um;
        public override void Do()
        {
            um.Add(new RenderTexDispose() { texture = proxy.texture });
            Condition = true;
        }
	}
	public class AddRenderTexToUnmanagedCntrLeaf: TreeProvider<AddRenderTexToUnmanagedCntr> { }
}
