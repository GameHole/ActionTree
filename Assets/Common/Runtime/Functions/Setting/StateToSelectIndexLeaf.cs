using ActionTree;
using UnityEngine;
namespace ActionTree
{
	public sealed class StateToSelectIndex:ATree
	{
        GameObjectCntr cntr;
        State state;
        IntValue index;
		public override void Do()
        {
            index.value = state.value % cntr.Length;
            Condition = true;
        }
	}
	public class StateToSelectIndexLeaf: TreeProvider<StateToSelectIndex> { }
}
