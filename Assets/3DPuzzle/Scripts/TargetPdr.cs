using System.Collections.Generic;
using ActionTree;
using UnityEngine;
namespace Default
{
	[System.Serializable]
	public sealed class Target : IComponent
	{
        public Transform value;
	}
	public class TargetPdr: CmpProvider<Target> { }
}
