using ActionTree;
using UnityEngine;
namespace ActionTree
{
	public sealed class PrePosition : IComponent
	{
        public Queue<Vector3> values = new Queue<Vector3>();
        //public bool cotainEx;
	}
	public class PrePositionPdr: CmpProvider<PrePosition> { }
}
