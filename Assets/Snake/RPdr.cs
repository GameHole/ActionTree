using System.Collections.Generic;
using ActionTree;
using UnityEngine;
namespace Default
{
	[System.Serializable]
	public sealed class R : IComponent
	{
        public float value = 0.5f;
        [HideInInspector] public float D2;
	}
	public class RPdr: CmpProvider<R>
    {
        public override IComponent GetValue()
        {
            value.D2 = 4 * value.value * value.value;
            return base.GetValue();
        }
    }
}
