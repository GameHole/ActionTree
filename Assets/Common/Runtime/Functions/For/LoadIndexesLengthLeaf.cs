using ActionTree;
using UnityEngine;
namespace ActionTree
{
	public sealed class LoadIndexesLength:ATree
	{
        Indexes indexes;
        IntValue output;
        public override void Do()
        {
            output.value = indexes.Length;
            Condition = true;
        }
	}
	public class LoadIndexesLengthLeaf: TreeProvider<LoadIndexesLength> { }
}
