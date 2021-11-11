using System.Collections.Generic;
using ActionTree;
using UnityEngine;
namespace ActionTree
{
	[System.Serializable]
	public sealed class VecToData : IComponent
	{
        public Vector3 start;
        public Vector3 end;
        [HideInInspector] public Vector3 dif;
        public bool isFast;
    }
	public class VecToDataPdr: CmpProvider<VecToData>
    {
        public override IComponent GetValue()
        {
            if (value.isFast)
                value.dif = value.end - value.start;
            return base.GetValue();
        }
    }
}
