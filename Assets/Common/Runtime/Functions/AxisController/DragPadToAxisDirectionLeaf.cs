using ActionTree;
using UnityEngine;
namespace ActionTree
{
    [MainThread]
	public sealed class DragPadToAxisDirection:ATree
	{
        Vector2Value direction;
        DragPadProxy proxy;
        FloatValue r;
		public override void Do()
        {
            Vector3 p = proxy.pad.transform.parent.InverseTransformPoint(proxy.position);
            Vector3 limit = p.normalized * r;
            float lx = Mathf.Abs(limit.x);
            p.x = Mathf.Clamp(p.x, -lx, lx);
            float ly = Mathf.Abs(limit.y);
            p.y = Mathf.Clamp(p.y, -ly, ly);
            Vector3 dir = new Vector3(p.x / r, p.y / r, 0);
            direction.value = dir;
            Condition = true;
        }
        public override void Clear()
        {
            base.Clear();
            direction.value = Vector3.zero;
        }
    }
	public class DragPadToAxisDirectionLeaf: TreeProvider<DragPadToAxisDirection> { }
}
