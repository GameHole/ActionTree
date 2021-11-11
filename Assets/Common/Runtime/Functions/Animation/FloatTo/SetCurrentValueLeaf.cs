using UnityEngine;
namespace ActionTree
{
	public sealed class SetCurrentValue:ATree
	{
        FloatValue value;
        FloatToData data;
		public override void Do()
        {
            data.start = value.value;
            Condition = true;
        }
	}
	public class SetCurrentValueLeaf: TreeProvider<SetCurrentValue> { }
}
