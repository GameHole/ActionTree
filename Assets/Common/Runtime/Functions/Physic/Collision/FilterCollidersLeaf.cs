using ActionTree;
using UnityEngine;
namespace ActionTree
{
    [MainThread]
	public sealed class FilterColliders:ATree
	{
        TriggerColiders coliders;
        Collisions collisions;
		public override void Do()
        {
            for (int i = 0; i < collisions.collisions.Count; i++)
            {
                coliders.colliders.Add(collisions.collisions[i].collider);
            }
            Condition = true;
        }
        public override void Clear()
        {
            base.Clear();
            coliders.colliders.Clear();
        }
    }
	public class FilterCollidersLeaf: TreeProvider<FilterColliders> { }
}
