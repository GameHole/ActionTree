//using ActionTree;
//using UnityEngine;
//namespace Default
//{
//	[MainThread]
//	public sealed class GenOpCube:ATree
//	{
//        SelectId select;
//        CombinedCubeCntr cubeCntr;
//        CubeCntr cntr;
//        CubePrefab prefab;
//        RaycastData data;
//        Target target;
//		public override void Do()
//        {
//            Debug.Log("gen");
//            var ui = prefab.prefabs.transform.Find("UI");
//            var cbm = cubeCntr.blocks[select.value];
//            var gened = new GameObject("block");
//            for (int i = 0; i < cbm.vertxes.Count; i++)
//            {
//                var clone = Object.Instantiate(ui);
//                clone.parent = gened.transform;
//                clone.localPosition = cbm.vertxes[i];
//            }
//            target.value = gened.transform;
//            var v = data.hit.collider.GetComponent<Id>().value;

//            gened.transform.position = prefab.uis[v].transform.position;
//            Condition = true;
//        }
//	}
//	public class GenOpCubeLeaf: TreeProvider<GenOpCube> { }
//}
