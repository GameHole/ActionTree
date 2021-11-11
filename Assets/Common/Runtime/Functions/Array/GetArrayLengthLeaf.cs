using ActionTree;
using UnityEngine;
namespace ActionTree
{
	public sealed class GetArrayLength:ATree
	{
        AArray array;
        IntValue len;
		public override void Do()
        {
            len.value = array.Length;
            Condition = true;
        }
	}
	public class GetArrayLengthLeaf: TreeProvider<GetArrayLength> { }
}
