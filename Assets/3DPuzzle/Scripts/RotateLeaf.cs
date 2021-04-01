using ActionTree;
using UnityEngine;
namespace ActionTree
{
	//[System.Serializable]
	public sealed class Rotate:ATree
	{
        Rotation rotation;
        RotateSpeed speed;
		public override void Do()
        {
            rotation.value *= Quaternion.AngleAxis(speed.speed * deltaTime, speed.axis);
            Condition = true;
        }
	}
	public class RotateLeaf: TreeProvider<Rotate> { }
}
