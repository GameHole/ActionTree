using System.Collections.Generic;
using ActionTree;
using UnityEngine;
namespace ActionTree
{
	[System.Serializable]
	public sealed class RotateToData : IComponent
	{
        public Vector3 startEuler;
        public Vector3 endEuler;
        [HideInInspector] public Quaternion start;
        [HideInInspector] public Quaternion end;
	}
	public class RotateToPdr: CmpProvider<RotateToData>
    {
        public override IComponent GetValue()
        {
            value.start = Quaternion.Euler(value.startEuler);
            value.end = Quaternion.Euler(value.endEuler);
            return base.GetValue();
        }
    }
}
