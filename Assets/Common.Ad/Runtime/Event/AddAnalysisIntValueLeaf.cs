using ActionTree;
using UnityEngine;
namespace ActionTree
{
	public sealed class AddAnalysisIntValue:ATree
	{
        ValuesPair pair;
        StringValue key;
        IntValue value;
		public override void Do()
        {
            pair.kvs[key] = value.value.ToString();
            Condition = true;
        }
	}
	public class AddAnalysisIntValueLeaf: TreeProvider<AddAnalysisIntValue> { }
}
