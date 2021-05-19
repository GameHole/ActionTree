using ActionTree;
using UnityEngine;
namespace ActionTree
{
    [MainThread]
	public sealed class SyncText:ATree
	{
        StringValue value;
        TextProxy proxy;
		public override void Do()
        {
            proxy.value.text = value.value;
            Condition = true;
        }
	}
	public class SyncTextLeaf: TreeProvider<SyncText> { }
}
