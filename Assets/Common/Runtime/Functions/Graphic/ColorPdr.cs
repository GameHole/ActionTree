using UnityEngine;

namespace ActionTree
{
    [System.Serializable]
	public sealed class ColorData : IComponent
	{
        public Color value;
	}
	public class ColorPdr: CmpProvider<ColorData> { }
}
