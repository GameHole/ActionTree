using ActionTree;
using UnityEngine;
namespace Default
{
	public sealed class PrePosition : IComponent
	{
        public Queue<Vector3> values = new Queue<Vector3>();
	}
	public class PrePositionPdr: CmpProvider<PrePosition> { }
}
