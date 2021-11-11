using ActionTree;
using UnityEngine;
namespace Washer
{
	public sealed class ConfigValueToString : ATree
	{
        ConfigFieldValue value;
        StringValue output;
		public override void Do()
        {
            output.value = (string)value.value;
            Condition = true;
        }
	}
	public class ConfigValueToStringLeaf : TreeProvider<ConfigValueToString> { }
}
