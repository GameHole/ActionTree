using ActionTree;
using UnityEngine;
namespace CrashSimulator
{
	public sealed class IsEqualInt:ATree
	{
        IntValue selected;
        IntValue compared;
        public override void Do()
        {
            Condition = selected.value == compared.value;
        }
	}
    //[RequireComponent(typeof(OverrideField))]
	public class IsEqualIntLeaf: TreeProvider<IsEqualInt> { }
}
