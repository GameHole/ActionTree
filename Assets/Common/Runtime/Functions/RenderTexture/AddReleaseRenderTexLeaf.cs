using ActionTree;
using UnityEngine;
namespace ActionTree
{
	public sealed class AddReleaseRenderTex:ATree
	{
        RenderTexProxy proxy;
        UnmanagedCntr um;
        public override void Do()
        {
            um.Add(new RenderTexRelease() { texture = proxy.texture });
            Condition = true;
        }
    }
	public class AddReleaseRenderTexLeaf: TreeProvider<AddReleaseRenderTex> { }
}
