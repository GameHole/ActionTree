using ActionTree;
using UnityEngine;
namespace ActionTree
{
    [MainThread]
	public sealed class GenCombined:ATree
	{
        SelectId id;
        Target target;
        Prefab prefab;
        public override void Do()
        {
            CombinedUICntr uis = driver.FindFirstCmp<CombinedUICntr>();
            CombinedCubeCntr cntr = driver.FindFirstCmp<CombinedCubeCntr>();
            //var center = new GameObject("center");
            //var ue = center.AddComponent<UnityEntity>();
            //var w = new WaitOne();
            //w.Add(ue);
            //w.Add<Active>();
            //var p = w.Add<Position>();
          
            //w.Add(new WaitDeactive());
            //var sync = new SyncP();
            //sync.Add<Boolen>().value = false;
            //w.Add(sync);
            //ue.tree = w;
            //w.Apply();
            ////Mgr.driver.AddEntity(ue.entity);
            //var data = cntr.blocks[id.value];
            //var d = ue.tree.Add<CombinedCubeUI>();
            //for (int i = 0; i < data.vertxes.Count; i++)
            //{
            //    var vtx = Object.Instantiate(prefab.prefab);
            //    var e = vtx.GetComponent<UnityEntity>();
            //    e.InitOnce();
            //    e.tree.Get<LocalVertex>().value = data.vertxes[i];
            //    vtx.transform.parent = center.transform;
            //    vtx.transform.localPosition = data.vertxes[i];
            //    vtx.transform.localScale *= 0.9f;
            //    d.entities.Add(e.tree);
            //}
            //d.data = data;
            //uis.items[id.value].SetActive(false);
            //target.value = ue.tree;
            Condition = true;
        }
	}
	public class GenCombinedLeaf: TreeProvider<GenCombined> { }
}
