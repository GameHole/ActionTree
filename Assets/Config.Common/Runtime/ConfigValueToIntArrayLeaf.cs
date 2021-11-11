using ActionTree;
using UnityEngine;
namespace ActionTree
{
	public sealed class ConfigValueToIntArray:ATree
	{
        ConfigFieldValue value;
        Array<int> array;
		public override void Do()
        {
            array.Set(value.value as int[]);
            Condition = true;
        }
	}
	public class ConfigValueToIntArrayLeaf: TreeProvider<ConfigValueToIntArray> { }
}
