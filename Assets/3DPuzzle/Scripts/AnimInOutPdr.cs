using System.Collections.Generic;
using ActionTree;
using UnityEngine;
namespace Default
{
	public sealed class AnimInOut : IComponent
	{
        public bool isIn;
	}
	public class AnimInOutPdr: CmpProvider<AnimInOut> { }
}
