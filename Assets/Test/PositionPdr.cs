using ActionTree;
using UnityEngine;
namespace Default
{
	//[System.Serializable]
	public sealed class Position : IComponent
	{
        public Vector3 value;
	}
	public class PositionPdr: CmpProvider<Position>
    {
        public override IComponent GetValue()
        {
            value.value = transform.position;
            return base.GetValue();
        }
    }
}
