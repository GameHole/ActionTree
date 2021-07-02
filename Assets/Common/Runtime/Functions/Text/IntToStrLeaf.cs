using ActionTree;
using UnityEngine;
namespace ActionTree
{
	public sealed class IntToStr:ATree
	{
        IntValue value;
        [AllowNull]IntValue offset;
        Format format;
        public override void Do()
        {
            int off = offset == null || value == offset ? 0 : offset.value;
            format[0] = value.value + off;
            Condition = true;
        }
	}
	public class IntToStrLeaf: TreeProvider<IntToStr> { }
}
