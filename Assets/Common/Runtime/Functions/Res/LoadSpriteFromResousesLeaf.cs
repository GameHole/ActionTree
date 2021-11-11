using ActionTree;
using System;
using UnityEngine;
using UnityEngine.U2D;

namespace ActionTree
{
    [MainThread]
	public sealed class LoadSpriteFromResouses:ATree
	{
        FilePath path;
        Sprites sprites;
        public override void Do()
        {
            var spa = Resources.Load<SpriteAtlas>(path.value);
            if (spa)
            {
                var buffer = new Sprite[spa.spriteCount];
                spa.GetSprites(buffer);
                foreach (var item in buffer)
                {
                    item.name = item.name.Replace("(Clone)","");
                }
                Array.Sort<Sprite>(buffer, (a, b) =>
                {
                    return string.Compare(a.name, b.name);
                });
                sprites.Set(buffer);
            }
            else
            {
                throw new Exception($"SpriteAtlas not found at path:{path.value}");
            }
            Condition = true;
        }
	}
	public class LoadSpriteFromResousesLeaf: TreeProvider<LoadSpriteFromResouses> { }
}
