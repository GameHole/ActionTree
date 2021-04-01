using ActionTree;
using UnityEngine;
namespace ActionTree
{
    [System.Serializable]
    public sealed class WaitInOut:ATree
	{
        AnimInOut anim;
        Boolen isOut;
        public override void Do()
        {
            Condition = anim.isIn ^ isOut.Value();
        }
	}
	public class WaitInOutLeaf: TreeProvider<WaitInOut> { }
}
