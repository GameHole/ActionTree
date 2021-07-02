using System.Collections.Generic;
using ActionTree;
using UnityEngine;
namespace ActionTree
{
	//[System.Serializable]
	public sealed class Rotation : IComponent
	{
        public Quaternion value;
	}
	public class RotationPdr: CmpProvider<Rotation>
    {
        public bool useCurrent;
        public override IComponent GetValue()
        {
            if (useCurrent)
                value.value = transform.rotation;
            else
                value.value = Quaternion.identity;
            return base.GetValue();
        }
    }
}
