using ActionTree;
using UnityEngine;
namespace Default
{
	public sealed class MoveSnake:ATree
	{
        Snake snake;
        //Offset offset;
        Speed speed;
        Boolen boolen;
        Direction direction;
		public override void Do()
        {
            if (snake.Head != null)
            {
                //Debug.Log(offset.value);
                var dir = snake.Head.Get<Direction>();
                //dir.value = (Vector3)offset.value * deltaTime * speed.value;
                dir.value = direction.value * deltaTime * speed.value;
            }
            Condition = boolen.Value();
        }
	}
	public class MoveSnakeLeaf: TreeProvider<MoveSnake> { }
}
