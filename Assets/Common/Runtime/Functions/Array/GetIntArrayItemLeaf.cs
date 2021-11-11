using ActionTree;
using UnityEngine;
namespace ActionTree
{
	public sealed class GetIntArrayItem:ATree
	{
        Array<int> array;
        IntValue index;
        IntValue output;
        public override void Do()
        {
            int idx = index;
            if (idx < 0)
                idx = 0;
            if (idx >= array.Length)
                idx = array.Length - 1;
            output.value = array[idx];
            Condition = true;
        }
	}
	public class GetIntArrayItemLeaf: TreeProvider<GetIntArrayItem> { }
}
