using ActionTree;
using UnityEngine;

namespace ActionTree
{
	public sealed class WaitTime:ATree
	{
        Time time;
        public override void Do()
        {
            time.add += deltaTime;
            Condition = time.add >= time.time;
        }
        public override void Clear()
        {
            base.Clear();
            time.add = 0;
        }
    }
	public class WaitTimeLeaf: TreeProvider<WaitTime> { }
}
