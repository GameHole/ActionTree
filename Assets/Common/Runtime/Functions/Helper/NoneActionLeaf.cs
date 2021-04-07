using ActionTree;
using UnityEngine;
namespace ActionTree
{
	public sealed class NoneAction:ATree
	{
		public override void Do() { }
	}
	public class NoneActionLeaf: TreeProvider<NoneAction> { }
}
