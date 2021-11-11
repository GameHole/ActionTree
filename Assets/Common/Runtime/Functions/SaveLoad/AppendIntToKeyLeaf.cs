using ActionTree;
using UnityEngine;
namespace ActionTree
{
	public sealed class AppendIntToKey:ATree
	{
        Key key;
        IntValue value;
		public override void Do()
        {
            key.value += value.value;
            Condition = true;
        }
	}
	public class AppendIntToKeyLeaf: TreeProvider<AppendIntToKey> { }
}
