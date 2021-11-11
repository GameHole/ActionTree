using ActionTree;
using UnityEngine;
namespace ActionTree
{
	public sealed class SetVectorToEnd:ATree
	{
        Vector3Value value;
        VecToData data;
		public override void Do()
        {
            data.end = value;
            Condition = true;
        }
	}
	public class SetVectorToEndLeaf: TreeProvider<SetVectorToEnd> { }
}
