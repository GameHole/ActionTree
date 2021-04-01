using ActionTree;
using UnityEngine;
namespace ActionTree
{
	public sealed class Follow:ATree
	{
        Position position;
        Target target;
		public override void Do()
        {
            var p = target.Get<Position>();
            if (p != null)
                p.value = position.value + Vector3.back * 10;
            //Condition = true;
            //Debug.Log("follow");
        }
	}
	public class FollowLeaf: TreeProvider<Follow> { }
}
