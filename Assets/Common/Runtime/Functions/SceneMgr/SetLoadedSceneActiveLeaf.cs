using ActionTree;
using UnityEngine;
namespace ActionTree
{
    [MainThread]
    [NotPreDo]
	public sealed class SetLoadedSceneActive:ATree
	{
        LoadAsyncParam param;
		public override void Do()
        {
            param.operation.allowSceneActivation = true;
            this.Log("active scene ");
            Condition = true;
        }
	}
	public class SetLoadedSceneActiveLeaf: TreeProvider<SetLoadedSceneActive> { }
}
