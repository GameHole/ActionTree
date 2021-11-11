using ActionTree;
using UnityEngine;
namespace ActionTree
{
	public sealed class SetFixedSpeedVectorTo : ATree
	{
        VecToData data;
        AnimDriveData driveData;
		public override void Do()
        {
            data.isFast = true;
            Vector3 dif = data.end - data.start;
            data.dif = dif.normalized;
            driveData.increaseRange.y = dif.magnitude;
            Condition = true;
        }
	}
	public class SetFixedSpeedVectorToLeaf : TreeProvider<SetFixedSpeedVectorTo> { }
}
