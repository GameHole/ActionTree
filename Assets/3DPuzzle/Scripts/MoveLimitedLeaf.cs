using ActionTree;
using UnityEngine;
namespace Default
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
