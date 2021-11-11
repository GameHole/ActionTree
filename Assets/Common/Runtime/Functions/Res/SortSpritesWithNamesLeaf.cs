using ActionTree;
using UnityEngine;
namespace ActionTree
{
    //[MainThread]
	public sealed class SortSpritesWithNames:SortWithNamesOrder<Sprite>
	{

    }
	public class SortSpritesWithNamesLeaf: TreeProvider<SortSpritesWithNames> { }
}
