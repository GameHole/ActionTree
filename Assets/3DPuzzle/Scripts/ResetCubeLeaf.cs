using ActionTree;
using UnityEngine;
namespace Default
{
	[MainThread]
    //[NotPreDo]
	public sealed class ResetCube:ATree
	{
        Target target;
        SelectId id;
        public override void Do()
        {
            Debug.Log("reset");
            CombinedUICntr uis = Entity.driver.FindFirstCmp<CombinedUICntr>();
           var ui= target.value.GetComponent<CombinedCubeUI>();
            for (int i = 0; i < ui.entities.Count; i++)
            {
                ui.entities[i].GetComponent<Active>().value = false;
                ui.entities[i].GetComponent<UnityEntity>().transform.parent = null;
            }
            target.value.GetComponent<Active>().value = false;
            uis.items[id.value].SetActive(true);
            Condition = true;
        }
	}
	public class ResetCubeLeaf: TreeProvider<ResetCube> { }
}
