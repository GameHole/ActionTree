using ActionTree;
using UnityEngine;
namespace Default
{
	[System.Serializable]
    [MainThread]
	public sealed class WaitAnim:ATree
	{
        public Animator animator;
        public bool isOut;
        public float speed = 1;
		public override void Do()
        {
            animator.speed = speed;
            animator.SetInteger("state", isOut ? 1 : 2);
            Condition = true;
        }
    }
	public class WaitAnimLeaf: TreeProvider<WaitAnim> { }
}
