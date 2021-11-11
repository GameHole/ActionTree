using ActionTree;
using MiniGameSDK;
using UnityEngine;
namespace ActionTree
{
    [MainThread]
	public sealed class ShowDialogPageAd:ATree
	{
		public override void Do()
        {
            var ad = RefinterEx.GetShared<IDialogPageAd>();
            if (ad != null)
            {
                ad.Show();
            }
            else
            {
                this.Log("ShowDialogPageAd");
            }
            Condition = true;
        }
	}
	public class ShowDialogPageAdLeaf: TreeProvider<ShowDialogPageAd> { }
}
