using ActionTree;
using UnityEngine;
namespace ActionTree
{
    [MainThread]
    public sealed class NewRenderTexture:ATree
	{
        RenderTexProxy proxy;
        UnmanagedCntr cntr;
        Vector2Value size;
		public override void Do()
        {
            proxy.texture = new RenderTexture((int)size.value.x, (int)size.value.y, 0);
            proxy.texture.Create();
            //this.Log($"o::{proxy.GetType()} p::{ proxy.texture}");
            cntr.Add(new RenderTexRelease() { texture = proxy.texture });
            Condition = true;
        }
	}
	public class NewRenderTextureLeaf: TreeProvider<NewRenderTexture> { }
}
