using UnityEngine.UI;

namespace ActionTree
{
    [System.Serializable]
	public sealed class ImageProxy : IComponent
	{
        public Image image;
	}
	public class ImageProxyPdr: CmpProvider<ImageProxy> { }
}
