using ActionTree;
using UnityEngine;
namespace Default
{
    //[MainThread]
    public sealed class UpdatePrePosition:ATree
    {
        PrePosition pre;
        Position position;
        R r;
        public override void Do()
        {
            while (pre.values.Count > 0)
            {
                if ((pre.values.Peek() - position.value).sqrMagnitude <= r.D2*1.5f)
                    break;
                pre.values.Dequeue();
            }
            pre.values.Enqueue(position.value);
            Condition = true;
        }
	}
	public class UpdatePrePositionLeaf: TreeProvider<UpdatePrePosition> { }
}
