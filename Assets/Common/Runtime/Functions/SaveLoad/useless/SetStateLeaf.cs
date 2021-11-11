using ActionTree;
using UnityEngine;
namespace ActionTree
{
	public sealed class SetState:ATree
	{
        State state;
        IntValue value;
		public override void Do()
        {
            state.value = value;
            Condition = true;
        }
	}
	public class SetStateLeaf: TreeProvider<SetState> { }
}
