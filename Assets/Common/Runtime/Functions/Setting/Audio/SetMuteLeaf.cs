using ActionTree;
using UnityEngine;
namespace ActionTree
{
    [MainThread]
	public sealed class SetMute:ATree
	{
        AudioCollector collector;
		public override void Do()
        {
            //this.Log($"SetMute {collector.isMute}");
            for (int i = collector.audios.Count-1; i >=0 ; i--)
            {
                collector.audios[i].mute = collector.isMute;
                //this.Log(collector.audios[i]);
            }
            Condition = true;
        }
	}
	public class SetMuteLeaf: TreeProvider<SetMute> { }
}
