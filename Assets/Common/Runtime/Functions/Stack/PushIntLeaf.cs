using ActionTree;
using UnityEngine;
namespace ActionTree
{
	public sealed class PushInt : Push<int> { }
	public class PushIntLeaf: TreeProvider<PushInt> { }
}
