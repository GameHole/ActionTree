using ActionTree;
using System.Text;
using UnityEngine;
namespace ActionTree
{
	public sealed class FormatAsKey:ATree
	{
        Format format;
        Key key;
        StringBuilder builder = new StringBuilder();
        public override void Do()
        {
            builder.Clear();
            for (int i = 0; i < format.param.Length; i++)
            {
                if (format.param[i] != null)
                {
                    builder.Append(format.param[i]);
                    builder.Append("_");
                }
            }
            key.value = builder.ToString();
            Condition = true;
        }
	}
	public class FormatAsKeyLeaf: TreeProvider<FormatAsKey> { }
}
