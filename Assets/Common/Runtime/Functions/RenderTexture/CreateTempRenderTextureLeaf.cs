using ActionTree;
using UnityEngine;
namespace ActionTree
{
    [MainThread]
	public sealed class CreateTempRenderTexture:ATree
	{
        RenderTexProxy proxy;
        Vector2Value size;
		public override void Do()
        {
            proxy.texture = RenderTexture.GetTemporary((int)size.value.x, (int)size.value.y);
            Condition = true;
        }
	}
	public class CreateTempRenderTextureLeaf : TreeProvider<CreateTempRenderTexture> { }
}
