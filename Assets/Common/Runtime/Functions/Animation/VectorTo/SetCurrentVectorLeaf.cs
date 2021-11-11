using ActionTree;
using UnityEngine;
namespace ActionTree
{
	public sealed class SetCurrentVector:ATree
	{
        VecToData data;
        Vector3Value value;
		public override void Do()
        {
            data.start = value;
            Condition = true;
        }
	}
	public class SetCurrentVectorLeaf: TreeProvider<SetCurrentVector> { }
}
