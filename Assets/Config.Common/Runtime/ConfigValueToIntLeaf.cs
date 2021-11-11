using ActionTree;
using UnityEngine;
namespace Washer
{
	public sealed class ConfigValueToInt:ATree
	{
        ConfigFieldValue value;
        IntValue output;
		public override void Do()
        {
            output.value = (int)value.value;
            Condition = true;
        }
	}
	public class ConfigValueToIntLeaf: TreeProvider<ConfigValueToInt> { }
}
