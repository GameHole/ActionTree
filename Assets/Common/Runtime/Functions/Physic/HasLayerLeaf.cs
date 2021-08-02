using ActionTree;
using UnityEngine;
namespace ActionTree
{
	public sealed class HasLayer:ATree
	{
        [AllowNull] TriggerColiders coliders;
        [AllowNull] Collisions collisions;
        LayerPoxy layer;
		public override void Do()
        {
            if (collisions != null)
            {
                var cs = collisions.collisions;
                for (int i = 0; i < cs.Count; i++)
                {
                    //this.Log($"sl::{cs[i].gameObject.layer.ToString("x")} ll:{layer.value.value.ToString("x")}");
                    if (contain(cs[i].gameObject.layer , layer.value))
                    {
                        Condition = true;
                        return;
                    }
                }
            }
            if (coliders != null)
            {
                var cs = coliders.colliders;
                for (int i = 0; i < cs.Count; i++)
                {
                    //this.Log($"sl::{cs[i].gameObject.layer.ToString("x")} ll:{layer.value.value.ToString("x")}");
                    if (contain(cs[i].gameObject.layer ,layer.value))
                    {
                        Condition = true;
                        return;
                    }
                }
            }
        }
        bool contain(int l,LayerMask mask)
        {
            int objLayerMask = 1 << l;
            return (mask.value & objLayerMask) > 0;
        }
	}
	public class HasLayerLeaf: TreeProvider<HasLayer> { }
}
