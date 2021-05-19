using ActionTree;
using UnityEngine;
namespace ActionTree
{
	public sealed class IntToStr:ATree
	{
        IntValue value;
        Format format;
        public override void Do()
        {
            format[0] = value.value;
            Condition = true;
        }
	}
	public class IntToStrLeaf: TreeProvider<IntToStr> { }
}
