using ActionTree;
using UnityEngine;
namespace ActionTree
{
	public sealed class AddState:ATree
	{
        State state;
        IntValue dv;
		public override void Do()
        {
            state.value += dv;
            Condition = true;
        }
	}
	public class AddStateLeaf: TreeProvider<AddState> { }
}
