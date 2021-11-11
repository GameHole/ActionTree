using ActionTree;
using UnityEngine;
namespace ActionTree
{
    [MainThread]
    public sealed class ActiveSelect:ATree
	{
        IntValue state;
        GameObjectCntr cntr;
		public override void Do()
        {
            for (int i = 0; i < cntr.Length; i++)
            {
                cntr[i].SetActive(i == state);
            }
            Condition = true;
        }
	}
	public class ActiveSelectLeaf: TreeProvider<ActiveSelect> { }
}
