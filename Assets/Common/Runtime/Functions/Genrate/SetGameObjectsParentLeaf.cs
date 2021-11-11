using ActionTree;
using UnityEngine;
namespace Washer
{
    [MainThread]
	public sealed class SetGameObjectsParent:ATree
	{
        GameObjectCntr cntr;
        UnityParent up;
		public override void Do()
        {
            foreach (var item in cntr)
            {
                item.transform.SetParent(up.value);
            }
            Condition = true;
        }
	}
	public class SetGameObjectsParentLeaf: TreeProvider<SetGameObjectsParent> { }
}
