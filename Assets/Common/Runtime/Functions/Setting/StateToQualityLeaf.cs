using ActionTree;
using UnityEngine;
namespace ActionTree
{
    [MainThread]
	public sealed class StateToQuality:ATree
	{
        IntValue state;
        QualityIndexs indexs;
		public override void Do()
        {
            int i = state.value;
            if (i >= indexs.indexs.Length)
                i = indexs.indexs.Length - 1;
            QualitySettings.SetQualityLevel((int)indexs.indexs[i]);
            Condition = true;
        }
	}
	public class StateToQualityLeaf: TreeProvider<StateToQuality> { }
}
