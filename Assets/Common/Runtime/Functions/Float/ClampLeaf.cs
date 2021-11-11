using ActionTree;
using UnityEngine;
namespace ActionTree
{
	public sealed class Clamp:ATree
	{
        FloatValue value;
        FloatRange range;
		public override void Do()
        {
            value.value = Mathf.Clamp(value.value,range.min,range.max);
            //Debug.Log(value.value);
        }
	}
	public class ClampLeaf: TreeProvider<Clamp> { }
}
