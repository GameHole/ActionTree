using ActionTree;
using UnityEngine;
namespace ActionTree
{
	public sealed class SortGameObjectsWithNames: SortWithNamesOrder<GameObject>
    {
	}
	public class SortGameObjectsWithNamesLeaf : TreeProvider<SortGameObjectsWithNames> { }
}
