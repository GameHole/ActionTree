using ActionTree;
using UnityEngine;
namespace ActionTree
{
	public sealed class PrePosition : IComponent
	{
        public MyQueue<Vector3> values = new MyQueue<Vector3>();
        //public bool cotainEx;
	}
	public class PrePositionPdr: CmpProvider<PrePosition> { }
}
