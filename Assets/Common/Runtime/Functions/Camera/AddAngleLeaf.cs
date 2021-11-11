using ActionTree;
using UnityEngine;
namespace ActionTree
{
	public sealed class AddAngle:ATree
	{
        FloatValue angle;
        Dir dir;
        Speed speed;
		public override void Do()
        {
            angle.value += speed.value * deltaTime * dir.value;
            Condition = true;
        }
	}
	public class AddAngleLeaf: TreeProvider<AddAngle> { }
}
