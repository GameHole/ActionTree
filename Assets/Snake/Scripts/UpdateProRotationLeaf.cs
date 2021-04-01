using ActionTree;
using UnityEngine;
namespace ActionTree
{
	public sealed class UpdateProRotation:ATree
	{
        Rotation rotation;
        Count last;
        PreRotation preRotation;
		public override void Do()
        {
            while (preRotation.rotateions.Count > last.value)
            {
                preRotation.rotateions.Dequeue();
            }
            preRotation.rotateions.Enqueue(rotation.value);
            Condition = true;
        }
	}
	public class UpdateProRotationLeaf: TreeProvider<UpdateProRotation> { }
}
