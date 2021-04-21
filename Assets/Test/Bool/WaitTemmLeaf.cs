using ActionTree;
using UnityEngine;
namespace ActionTree
{
	public sealed class WaitTemm : WaitBoolen<Temm> { }
	public class WaitTemmLeaf: TreeProvider<WaitTemm> { }
}
