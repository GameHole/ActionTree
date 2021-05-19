using ActionTree;
using UnityEngine;
namespace ActionTree
{
	public sealed class CombineFormat:ATree
	{
        Format format;
        StringValue value;
        public override void Do()
        {
            if (format.param != null)
            {
                value.value = string.Format(format.value, format.param);
                Condition = true;
            }
        }
	}
	public class CombineFormatLeaf: TreeProvider<CombineFormat> { }
}
