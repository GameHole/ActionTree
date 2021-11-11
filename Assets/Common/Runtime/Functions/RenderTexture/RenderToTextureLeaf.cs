using ActionTree;
using UnityEngine;
namespace ActionTree
{
    [MainThread]
	public sealed class RenderToTexture:ATree
	{
        CameraProxy camera;
        RenderTexProxy rdtex;
		public override void Do()
        {
            camera.value.targetTexture = rdtex.texture;
            Condition = true;
        }
	}
	public class RenderToTextureLeaf: TreeProvider<RenderToTexture> { }
}
