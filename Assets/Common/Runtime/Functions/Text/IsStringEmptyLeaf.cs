using ActionTree;
using UnityEngine;
namespace ActionTree
{
	public sealed class IsStringEmpty:ATree
	{
        StringValue value;
        [AllowNull] Boolen isInverse;
		public override void Do()
        {
            Condition = isInverse.Value(false) ^ string.IsNullOrEmpty(value);
        }
	}
	public class IsStringEmptyLeaf: TreeProvider<IsStringEmpty> { }
}
