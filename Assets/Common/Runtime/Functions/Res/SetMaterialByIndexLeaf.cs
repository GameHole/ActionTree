using ActionTree;
using UnityEngine;
namespace ActionTree
{
    [MainThread]
	public sealed class SetMaterialByIndex:ATree
	{
        GameObjectProxy proxy;
        Materials materials;
        IntValue index;
		public override void Do()
        {
            proxy.target.GetComponent<MeshRenderer>().material = materials[index];
            Condition = true;
        }
	}
	public class SetMaterialByIndexLeaf: TreeProvider<SetMaterialByIndex> { }
}
