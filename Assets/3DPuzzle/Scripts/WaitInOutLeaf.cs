using ActionTree;
using UnityEngine;
namespace Default
{
    [System.Serializable]
    public sealed class WaitInOut:ATree
	{
        AnimInOut anim;
        public bool isOut;
		public override void Do()
        {
            Condition = anim.isIn ^ isOut;
        }
	}
	public class WaitInOutLeaf: TreeProvider<WaitInOut> { }
}
