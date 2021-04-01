using ActionTree;
using UnityEngine;
namespace ActionTree
{
	public sealed class UpdateRotation:ATree
	{
        Rotation rotation;
        Target target;
        LerpedInfo lerped;
        public override void Do()
        {
            var tpr = target.value.Get<PreRotation>();
            if (lerped.inId == -1)
            {
                var tp= target.value.Get<Rotation>();
                rotation.value = Quaternion.Slerp(tpr.rotateions[lerped.exId], tp.value, lerped.t);
            }
            else
            {
                rotation.value = Quaternion.Slerp(tpr.rotateions[lerped.exId], tpr.rotateions[lerped.inId], lerped.t);
            }
            Condition = true;
        }
	}
	public class UpdateRotationLeaf: TreeProvider<UpdateRotation> { }
}
