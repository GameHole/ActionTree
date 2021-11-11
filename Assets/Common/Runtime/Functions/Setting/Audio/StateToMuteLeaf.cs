using ActionTree;
using UnityEngine;
namespace ActionTree
{
	public sealed class StateToMute:ATree
	{
        [Finded] AudioCollector collector;
        IntValue state;
		public override void Do()
        {
            collector.isMute = state == 1;
            Condition = true;
        }
	}
	public class StateToMuteLeaf: TreeProvider<StateToMute> { }
}
