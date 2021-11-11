using ActionTree;
using UnityEngine;
namespace ActionTree
{
	public sealed class IsEqualInt:ATree
	{
        IntValue selected;
        IntValue compared;
        [AllowNull] Boolen isInverse;
        public override void Do()
        {
            Condition = isInverse.Value(false) ^ selected.value == compared.value;
        }
	}
    //[RequireComponent(typeof(OverrideField))]
	public class IsEqualIntLeaf: TreeProvider<IsEqualInt> { }
}
