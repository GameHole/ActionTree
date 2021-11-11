using ActionTree;
using UnityEngine;
namespace Washer
{
	public sealed class ConfigValueToFloat : ATree
	{
        ConfigFieldValue value;
        FloatValue output;
		public override void Do()
        {
            output.value = (float)value.value;
            Condition = true;
        }
	}
	public class ConfigValueToFloatLeaf : TreeProvider<ConfigValueToFloat> { }
}
