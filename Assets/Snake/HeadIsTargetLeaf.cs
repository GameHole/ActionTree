using ActionTree;
using UnityEngine;
namespace Default
{
	public sealed class HeadIsTarget:ATree
	{
        Target target;
        public Snake snake;
		public override void Do()
        {
            if(driver.TryFindFirstCmp(ref snake))
            {
                if (snake.Head != null)
                {
                    target.value = snake.Head;
                    Condition = true;
                }
            }
        }
	}
	public class HeadIsTargetLeaf: TreeProvider<HeadIsTarget> { }
}
