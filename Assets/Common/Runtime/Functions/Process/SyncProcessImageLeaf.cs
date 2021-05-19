using ActionTree;
using UnityEngine;
namespace ActionTree
{
    [MainThread]
	public sealed class SyncProcessImage:ATree
	{
        Process process;
        ImageProxy proxy;
		public override void Do()
        {
            if (proxy.image)
                proxy.image.fillAmount = process.value;
            Condition = true;
        }
	}
	public class SyncProcessImageLeaf : TreeProvider<SyncProcessImage> { }
}
