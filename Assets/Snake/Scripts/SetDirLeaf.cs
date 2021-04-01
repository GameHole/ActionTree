using ActionTree;
using UnityEngine;
namespace ActionTree
{
	public sealed class SetDir:ATree
	{
        Direction direction;
		public override void Do()
        {
            
        }
	}
	public class SetDirLeaf: TreeProvider<SetDir> { }
}
