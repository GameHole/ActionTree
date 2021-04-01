using ActionTree;
using UnityEngine;
namespace ActionTree
{
	[System.Serializable]
	public sealed class MoveLimited:ATree
	{
        Target target;
        RaycastData data;
		public override void Do()
        {
            
        }
	}
	public class MoveLimitedLeaf: TreeProvider<MoveLimited> { }
}
