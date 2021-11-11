using ActionTree;
using UnityEngine;
namespace ActionTree
{
    [MainThread]
	public sealed class CleanNullAudio:ATree
	{
        AudioCollector collector;
        public override void Do()
        {
            //this.Log($"clean {collector.audios.Count}");
            for (int i = collector.audios.Count - 1; i >= 0; i--)
            {
                var m = collector.audios[i];
                if (!m)
                {
                    collector.audios.Remove(m);
                }
            }
            Condition = true;
        }
	}
	public class CleanNullAudioLeaf: TreeProvider<CleanNullAudio> { }
}
