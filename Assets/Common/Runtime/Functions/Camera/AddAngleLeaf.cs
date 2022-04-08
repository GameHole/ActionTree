using ActionTree;
using UnityEngine;
namespace ActionTree
{
	public sealed class AddAngle:ATree
	{
        FloatValue angle;
        Dir dir;
        Speed speed;
        FloatValue sencity;
		public override void Do()
        {
            angle.value += speed.value * deltaTime * dir.value / sencity.value;
            Condition = true;
        }
	}
	public class AddAngleLeaf: TreeProvider<AddAngle> { }
}
