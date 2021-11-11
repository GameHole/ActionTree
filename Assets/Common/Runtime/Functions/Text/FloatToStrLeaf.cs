using ActionTree;
using UnityEngine;
namespace ActionTree
{
	public sealed class FloatToStr:ATree
	{
        FloatValue value;
        Format format;
        [AllowNull]IntValue frag;
		public override void Do()
        {
            int f = 2;
            if (frag != null)
                f = frag.value;
            format[0] = value.value.ToString($"f{f}");
            Condition = true;
        }
	}
	public class FloatToStrLeaf: TreeProvider<FloatToStr> { }
}
