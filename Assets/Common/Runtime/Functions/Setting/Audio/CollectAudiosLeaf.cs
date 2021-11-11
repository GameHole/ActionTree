using ActionTree;
using UnityEngine;
namespace ActionTree
{
    [MainThread]
	public sealed class CollectAudios:ATree
	{
        [Finded] AudioCollector collector;
        UnityParent uparent;
		public override void Do()
        {
            var cs = uparent.value.GetComponentsInChildren<AudioSource>();
            //this.Log(cs.Length);
            collector.audios.AddRange(cs);
            Condition = true;
        }
	}
	public class CollectAudiosLeaf: TreeProvider<CollectAudios> { }
}
