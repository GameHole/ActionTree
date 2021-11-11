using ActionTree;
using UnityEngine;
namespace ActionTree
{
	public sealed class SetVec2Value:ATree
	{
        Vector2Value left;
        Vector2Value right;
		public override void Do()
        {
            left.value = right.value;
            Condition = true;
        }
	}
	public class SetVec2ValueLeaf: TreeProvider<SetVec2Value> { }
}
