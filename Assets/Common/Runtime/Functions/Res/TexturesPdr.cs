using System.Collections.Generic;
using ActionTree;
using UnityEngine;
namespace ActionTree
{
	[System.Serializable]
	public sealed class Textures : IComponent
	{
        public Texture[] values;
	}
	public class TexturesPdr: CmpProvider<Textures> { }
}
