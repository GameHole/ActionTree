using ActionTree;
using UnityEngine;
namespace Default
{
	public sealed class MovHead:ATree
	{
        Direction direction;
        Position position;
		public override void Do()
        {
            position.value += direction.value;
        }
	}
	public class MovHeadLeaf: TreeProvider<MovHead> { }
}
