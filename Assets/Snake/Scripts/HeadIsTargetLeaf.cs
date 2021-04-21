using ActionTree;
using UnityEngine;
namespace ActionTree
{
    [MainThread]
	public sealed class HeadIsTarget:ATree
	{
        Target target;
        //public Snake snake;
		public override void Do()
        {
            if (target.isNull())
            {
                target.value = Camera.main.GetComponent<UnityEntity>().entity;
                Condition = true;
            }
            //if(driver.TryFindFirstCmp(ref snake))
            //{
            //    if (snake.Head != null)
            //    {
            //        target.value = snake.Head;
            //        Condition = true;
            //    }
            //}
        }
	}
	public class HeadIsTargetLeaf: TreeProvider<HeadIsTarget> { }
}
