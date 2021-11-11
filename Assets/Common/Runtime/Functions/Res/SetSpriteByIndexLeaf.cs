using ActionTree;
using UnityEngine;
namespace ActionTree
{
    [MainThread]
	public sealed class SetSpriteByIndex:ATree
	{
        IntValue index;
        Sprites sprites;
        ImageProxy image;
		public override void Do()
        {
            int idx = index.value;
            //this.Log(idx);
            if (idx >= 0 && idx < sprites.Length)
            {
                image.image.sprite = sprites[idx];
                image.image.SetNativeSize();
            }
            else
            {
                this.Warning("index out of range");
            }
            Condition = true;
        }
	}
	public class SetSpriteByIndexLeaf: TreeProvider<SetSpriteByIndex> { }
}
