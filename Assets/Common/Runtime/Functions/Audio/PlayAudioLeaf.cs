using ActionTree;
using UnityEngine;
namespace ActionTree
{
    [MainThread]
	public sealed class PlayAudio:ATree
	{
        AudioProxy proxy;
        Boolen isPlay;
        public override void Do()
        {
            if (isPlay)
            {
                if (!proxy.source.isPlaying)
                    proxy.source.Play();
            }
            else
            {
                if (proxy.source.isPlaying)
                    proxy.source.Stop();
            }
            Condition = true;
        }
	}
	public class PlayAudioLeaf: TreeProvider<PlayAudio> { }
}
