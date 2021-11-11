using ActionTree;
using MiniGameSDK;
using UnityEngine;
namespace ActionTree
{
    [MainThread]
	public sealed class ShowBanner:ATree
	{
        Boolen isShow;
        public override void Do()
        {
            var ba = RefinterEx.GetShared<IBannerAd>();
            if (ba != null)
            {
                if (isShow.value)
                {
                    ba.Show();
                }
                else
                {
                    ba.Hide();
                }
            }
            else
            {
                this.Log($"banner {(isShow.value?"Show":"Hide")}");
            }
            Condition = true;
        }
	}
	public class ShowBannerLeaf: TreeProvider<ShowBanner> { }
}
