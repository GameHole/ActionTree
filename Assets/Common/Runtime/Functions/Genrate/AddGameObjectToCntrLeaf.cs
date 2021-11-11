using ActionTree;
using UnityEngine;
namespace ActionTree
{
    [MainThread]
	public sealed class AddGameObjectToCntr:ATree
	{
        GameObjectProxy go;
        GameObjectCntr cntr;
		public override void Do()
        {
            cntr.Add(go.target);
            Condition = true;
        }
	}
	public class AddGameObjectToCntrLeaf: TreeProvider<AddGameObjectToCntr> { }
}
