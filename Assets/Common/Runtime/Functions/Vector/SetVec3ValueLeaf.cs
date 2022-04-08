using ActionTree;
using UnityEngine;
namespace ActionTree
{
	public sealed class SetVec3Value : ATree
	{
        Vector3Value left;
        Vector3Value right;
		public override void Do()
        {
            left.value = right.value;
            Condition = true;
        }
	}
	public class SetVec3ValueLeaf : TreeProvider<SetVec3Value> { }
}
