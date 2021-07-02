using ActionTree;
using UnityEngine;
namespace ActionTree
{
    [System.Serializable]
    public sealed class Position : IComponent
	{
        public Vector3 value;
	}
	public class PositionPdr: CmpProvider<Position>
    {
        public bool useCurrent;
        public override IComponent GetValue()
        {
            if (useCurrent)
                value.value = transform.position;
            return base.GetValue();
        }
    }
}
