using ActionTree;
using UnityEngine;
namespace Default
{
	public sealed class Follow:ATree
	{
        Position position;
        Target target;
		public override void Do()
        {
            var p = target.Get<Position>();
            if (p!=null)
            position.value = p.value + Vector3.back * 10;
            Condition = true;
        }
	}
	public class FollowLeaf: TreeProvider<Follow> { }
}
