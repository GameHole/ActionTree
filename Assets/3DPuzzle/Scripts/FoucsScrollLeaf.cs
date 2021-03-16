using ActionTree;
using UnityEngine;
namespace Default
{
	[MainThread]
	public sealed class FoucsScroll:ATree
	{
        FocusedScroll scroll;
        UnityEntity entity;
		public override void Do()
        {
            float w = entity.GetComponent<RectTransform>().rect.width;
            //Debug.Log($"c{scroll.gp.childCount} w::{w}");
            for (int i = 0; i < scroll.gp.childCount; i++)
            {
                var child = scroll.gp.GetChild(i);
                var local = child.localPosition + scroll.gp.localPosition;
                child.localScale = Vector3.one * Mathf.Clamp(Mathf.Cos(10 * Mathf.Abs(local.x) / w), 0.5f, 1);
            }
            Condition = true;
        }
	}
	public class FoucsScrollLeaf: TreeProvider<FoucsScroll> { }
}
