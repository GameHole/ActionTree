using System.Collections.Generic;
using ActionTree;
using UnityEngine;
using MiniGameSDK;
namespace ActionTree
{
	//[System.Serializable]
	public sealed class RewardAdProxy : Boolen
	{
        public IRewardAdAPI reward;
	}
	public class RewardAdProxyPdr: CmpProvider<RewardAdProxy>
    {
        public override IComponent GetValue()
        {
            value.reward = RefinterEx.GetShared<IRewardAdAPI>();
            return base.GetValue();
        }
    }
}
