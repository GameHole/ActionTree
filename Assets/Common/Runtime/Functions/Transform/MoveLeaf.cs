using ActionTree;
using UnityEngine;
namespace ActionTree
{
	public sealed class Move:ATree
	{
        Position position;
        Direction direction;
        FloatValue speed;
		public override void Do()
        {
            position.value += direction.value * speed * deltaTime;
            Condition = true;
        }
	}
	public class MoveLeaf: TreeProvider<Move> { }
}
