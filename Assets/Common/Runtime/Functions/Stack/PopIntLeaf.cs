using ActionTree;
using UnityEngine;
namespace ActionTree
{
	public sealed class PopInt:Pop<int>
	{
	}
	public class PopIntLeaf: TreeProvider<PopInt> { }
}
