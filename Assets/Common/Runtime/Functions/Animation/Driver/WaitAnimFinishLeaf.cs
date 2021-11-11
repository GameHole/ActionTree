using ActionTree;
using UnityEngine;
namespace ActionTree
{
	public sealed class WaitAnimFinish:ATree
	{
        AnimDriveData data;
        Speed speed;
        public override void Do()
        {
            Condition = speed.Speed() >= 0 ? data.value >= data.increaseRange.y : data.value <= data.increaseRange.x;
        }
	}
	public class WaitAnimFinishLeaf: TreeProvider<WaitAnimFinish> { }
}
