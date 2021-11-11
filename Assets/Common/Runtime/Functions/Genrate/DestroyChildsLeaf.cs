using ActionTree;
using UnityEngine;
namespace ActionTree
{
    [MainThread]
	public sealed class DestroyChilds:ATree
	{
        UnityParent unityParent;
		public override void Do()
        {
            for (int i = 0, c = unityParent.value.childCount; i < c; i++)
            {
                Object.Destroy(unityParent.value.GetChild(i).gameObject);
            }
            Condition = true;
        }
	}
	public class DestroyChildsLeaf: TreeProvider<DestroyChilds> { }
}
