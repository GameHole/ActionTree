using ActionTree;
using UnityEngine;
namespace ActionTree
{
    //[MainThread]
	public sealed class SetAdInterfaceNull:ATree
	{
        AdType type;
		public override void Do()
        {
            System.Type iType = null;
            switch (type.type)
            {
                case AdType.AdTypeEnum.Reward:
                    iType = typeof(MiniGameSDK.IRewardAdAPI);
                    break;
                case AdType.AdTypeEnum.Banner:
                    iType = typeof(MiniGameSDK.IBannerAd);
                    break;
                case AdType.AdTypeEnum.Interstitial:
                    iType = typeof(MiniGameSDK.IInterstitialAdAPI);
                    break;
            }
            if (iType != null)
                RefinterEx.SetShared(iType, null);
            //this.Log("adad");
            Condition = true;
        }
	}
	public class SetAdInterfaceNullLeaf: TreeProvider<SetAdInterfaceNull> { }
}
