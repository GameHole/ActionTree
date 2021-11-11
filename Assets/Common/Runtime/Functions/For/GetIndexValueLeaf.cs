using ActionTree;
using UnityEngine;
namespace ActionTree
{
	public sealed class GetIndexValue:ATree
	{
        Indexes indexes;
        IntValue index;
        IntValue output;
		public override void Do()
        {
            output.value = indexes[index];
            Condition = true;
        }
	}
	public class GetIndexValueLeaf: TreeProvider<GetIndexValue> { }
}
