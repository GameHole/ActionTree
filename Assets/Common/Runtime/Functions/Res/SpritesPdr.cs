using System.Collections.Generic;
using ActionTree;
using UnityEngine;
namespace ActionTree
{
	[System.Serializable]
	public sealed class Sprites : Array<Sprite>
	{
        //public Sprite[] sprites;
	}
	public class SpritesPdr: CmpProvider<Sprites> { }
}
