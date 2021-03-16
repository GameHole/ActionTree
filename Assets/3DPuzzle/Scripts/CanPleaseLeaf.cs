using ActionTree;
using UnityEngine;
namespace Default
{
	//[System.Serializable]
	public sealed class CanPlease:ATree
	{
		public override void Do()
        {
            
        }
	}
	public class CanPleaseLeaf: TreeProvider<CanPlease> { }
}
