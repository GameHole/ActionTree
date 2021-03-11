using ActionTree;
using UnityEngine;

namespace Default
{
	[System.Serializable]
	public sealed class WaitTime:ATree
	{
        public float add;
        public float time;
		public override void Do()
        {
            add += deltaTime;
            Condition = add >= time;
        }
        public override void Clear()
        {
            base.Clear();
            add = 0;
        }
    }
	public class WaitTimeLeaf: TreeProvider<WaitTime> { }
}
