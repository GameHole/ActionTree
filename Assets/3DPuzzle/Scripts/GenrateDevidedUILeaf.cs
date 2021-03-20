using ActionTree;
using UnityEngine;
namespace Default
{
	[MainThread]
	public sealed class GenrateDevidedUI:ATree
	{
        CombinedUICntr uicntr;
        CombinedCubeCntr cubeCntr;
        CubePrefab prefab;
		public override void Do()
        {
            Condition = true;
            for (int i = 0; i < cubeCntr.blocks.Count; i++)
            {
                var block = cubeCntr.blocks[i];
                var clone = Object.Instantiate(uicntr.item);
                var e = clone.GetComponentInChildren<UnityEntity>();
                clone.transform.SetParent(uicntr.parent);
                clone.transform.localPosition = Vector3.zero;
                clone.transform.localScale = Vector3.one;
                SetUI(block, e.transform);
                uicntr.items.Add(clone);
                uicntr.clicks.Add(clone.GetComponentInChildren<PointInImage>());
            }
            //uicntr.item.gameObject.SetActive(false);
        }
        void SetUI(CombinedCube block, Transform parent)
        {
            var prefabui = prefab.prefabs.transform.Find("UI");
            Vector3 center = Vector3.zero;
            //for (int i = 0; i < block.vertxes.Count; i++)
            //{
            //    center += (Vector3)block.vertxes[i];
            //}
            //center /= block.vertxes.Count;
            for (int j = 0; j < block.vertxes.Count; j++)
            {
                var clone = Object.Instantiate(prefabui);
                clone.parent = parent;
                clone.localPosition = (block.vertxes[j] - center) * clone.localScale.x;
                clone.localScale *= 0.8f;
                clone.gameObject.layer = LayerMask.NameToLayer("UI");
                var r = clone.GetComponent<MeshRenderer>();
                r.receiveShadows = false;
                r.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
            }
        }
	}
	public class GenrateDevidedUILeaf: TreeProvider<GenrateDevidedUI> { }
}
