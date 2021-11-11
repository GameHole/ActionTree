using ActionTree;
using UnityEngine;
namespace ActionTree
{
    [MainThread]
	public sealed class SaveSprite:ATree
	{
        Sprites sprites;
        IntValue index;
        ImageProxy proxy;
		public override void Do()
        {
            sprites[index] = proxy.image.sprite;
            Condition = true;
        }
	}
	public class SaveSpriteLeaf: TreeProvider<SaveSprite> { }
}
