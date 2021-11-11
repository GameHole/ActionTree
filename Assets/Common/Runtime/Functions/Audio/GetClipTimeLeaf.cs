using ActionTree;
using UnityEngine;
namespace ActionTree
{
    [MainThread]
	public sealed class GetClipTime:ATree
	{
        AudioProxy proxy;
        Time time;
		public override void Do()
        {
            var clip = proxy.source.clip;
            time.time = clip ? clip.length : 0;
            Condition = true;
        }
	}
	public class GetClipTimeLeaf: TreeProvider<GetClipTime> { }
}
