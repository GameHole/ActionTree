using System.Collections.Generic;
using ActionTree;
using UnityEngine;
namespace ActionTree
{
	[System.Serializable]
	public sealed class EulerAngle : Vector3Value
	{
        //public Vector3 value;
	}
	public class EulerAnglePdr: CmpProvider<EulerAngle> { }
}
