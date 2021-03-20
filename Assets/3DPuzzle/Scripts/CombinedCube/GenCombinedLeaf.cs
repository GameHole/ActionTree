using ActionTree;
using UnityEngine;
namespace Default
{
    [MainThread]
	public sealed class GenCombined:ATree
	{
        SelectId id;
        Target target;
        Prefab prefab;
        public override void Do()
        {
            CombinedUICntr uis = Entity.driver.FindFirstCmp<CombinedUICntr>();
            CombinedCubeCntr cntr = Entity.driver.FindFirstCmp<CombinedCubeCntr>();
            var center = new GameObject("center");
            var ue = center.AddComponent<UnityEntity>();
            ue.entity = new Entity();
            ue.entity.Add(ue);
            ue.entity.AddComponent<Active>();
            var p = ue.entity.AddComponent<Position>();
            var w = new WaitOne();
            w.Add(new WaitDeactive());
            w.Add(new SyncP() { MenuCondition = false });
            ue.entity.SetTree(w);
            //Mgr.driver.AddEntity(ue.entity);
            var data = cntr.blocks[id.value];
            var d = ue.entity.AddComponent<CombinedCubeUI>();
            for (int i = 0; i < data.vertxes.Count; i++)
            {
                var vtx = Object.Instantiate(prefab.prefab);
                var e = vtx.GetComponent<UnityEntity>();
                e.Init();
                e.entity.GetComponent<LocalVertex>().value = data.vertxes[i];
                vtx.transform.parent = center.transform;
                vtx.transform.localPosition = data.vertxes[i];
                vtx.transform.localScale *= 0.9f;
                d.entities.Add(e.entity);
            }
            d.data = data;
            uis.items[id.value].SetActive(false);
            target.value = ue.entity;
            Condition = true;
        }
	}
	public class GenCombinedLeaf: TreeProvider<GenCombined> { }
}
