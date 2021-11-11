using ActionTree;
using UnityEngine;
using MiniGameSDK;
namespace ActionTree
{
    [MainThread]
	public sealed class ShowInterstitialAd:ATree
	{
        public override void Do()
        {
            var ad = RefinterEx.GetShared<IInterstitialAdAPI>();
            if (ad != null)
            {
                ad.Show();
            }
            else
            {
                this.Log("ShowInterstitialAd");
            }
            Condition = true;
        }
	}
	public class ShowInterstitialAdLeaf: TreeProvider<ShowInterstitialAd> { }
}
