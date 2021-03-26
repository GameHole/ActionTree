using System.Collections.Generic;
using ActionTree;
using UnityEngine;
namespace Default
{
	//[System.Serializable]
	public sealed class Rotation : IComponent
	{
        public Quaternion value;
	}
	public class RotationPdr: CmpProvider<Rotation>
    {
        public override IComponent GetValue()
        {
            value.value = transform.rotation;
            return base.GetValue();
        }
    }
}
