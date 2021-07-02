using ActionTree;
using UnityEngine;
namespace ActionTree
{
	public sealed class IsGreateThan:ATree
	{
        IntValue value;
        IntValue compare;
        [AllowNull]Boolen isInverse;
		public override void Do()
        {
            Condition = isInverse.Value(false) ^ value.value >= compare.value;
            //this.Log($" s {value.value},cmp {compare.value} c {Condition}");
        }
	}
	public class IsGreateThanLeaf: TreeProvider<IsGreateThan> { }
}
