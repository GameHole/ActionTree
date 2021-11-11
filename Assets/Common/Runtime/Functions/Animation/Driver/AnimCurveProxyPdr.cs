using System.Collections.Generic;
using ActionTree;
using UnityEngine;
namespace ActionTree
{
	[System.Serializable]
	public sealed class AnimCurveProxy : IComponent
	{
       public AnimationCurve curve;
	}
	public class AnimCurveProxyPdr: CmpProvider<AnimCurveProxy> { }
}
