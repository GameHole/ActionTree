using ActionTree;
using UnityEngine;
using MiniGameSDK;
namespace ActionTree
{
	public sealed class WaitReward : WaitBoolen<RewardAdProxy> { }
	public class WaitRewardLeaf: TreeProvider<WaitReward> { }
}
