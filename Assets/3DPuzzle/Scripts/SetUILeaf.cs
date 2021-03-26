using ActionTree;
using UnityEngine;
namespace Default
{
    [MainThread]
    public sealed class SetUIS:ATree
	{
        Target target;
        public Target tranedUI;
		public override void Do()
        {
            var anim = driver.FindFirstCmp<AnimInOut>();
            anim.isIn = true;
            tranedUI.value = target.value;
            target.value = null;
            Condition = true;
        }
	}
	public class SetUILeaf : TreeProvider<SetUIS>
    {
        public TargetPdr pdr;
        public override ETree GetTree()
        {
            value.tranedUI = pdr.value;
            return base.GetTree();
        }
    }
}
