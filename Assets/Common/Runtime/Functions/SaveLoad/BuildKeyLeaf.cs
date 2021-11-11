using ActionTree;
using System.Text;
using UnityEngine;
namespace ActionTree
{
	public sealed class BuildKey:ATree
	{
        KeyBuilder builder;
        StringValue output;
        StringBuilder catche = new StringBuilder();
        public override void Do()
        {
            catche.Clear();
            var bd = builder.builder;
            for (int i = 0; i <bd.Count; i++)
            {
                catche.Append(bd[i]);
                catche.Append("_");
            }
            output.value = builder.ToString();
            Condition = true;
        }
	}
	public class BuildKeyLeaf: TreeProvider<BuildKey> { }
}
