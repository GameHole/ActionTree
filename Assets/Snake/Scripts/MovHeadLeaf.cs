using ActionTree;
using UnityEngine;
namespace ActionTree
{
	public sealed class MovHead:ATree
	{
        Direction direction;
        Position position;
		public override void Do()
        {
            position.value += direction.value;
            //Debug.Log("mov");
        }
	}
	public class MovHeadLeaf: TreeProvider<MovHead> { }
}
