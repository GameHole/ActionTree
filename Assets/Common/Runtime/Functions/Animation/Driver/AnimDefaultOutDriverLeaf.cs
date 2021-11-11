using ActionTree;
using UnityEngine;
namespace ActionTree
{
	public sealed class AnimDefaultOutDriver:ATree
	{
        AnimDriveData data;
        AnimDriveOutPut outPut;
		public override void Do()
        {
            outPut.value = data.value;
            Condition = true;
        }
	}
	public class AnimDefaultOutDriverLeaf: TreeProvider<AnimDefaultOutDriver> { }
}
