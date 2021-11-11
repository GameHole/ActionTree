using ActionTree;
using MiniGameSDK;
using UnityEngine;
namespace ActionTree
{
    [MainThread]
	public sealed class ShowReward:ATree
	{
        RewardAdProxy proxy;
		public override void Do()
        {
            proxy.value = false;
            if (proxy.reward != null)
            {
                proxy.reward.AutoShow((v) => { proxy.value = v; });
            }
            else
            {
                proxy.value = true;
            }
            Condition = true;
        }
	}
	public class ShowRewardLeaf: TreeProvider<ShowReward> { }
}
