using System.Collections.Generic;
using ActionTree;
using UnityEngine;
namespace Default
{
	[System.Serializable]
	public sealed class AnimatorProxy : IComponent
	{
        public Animator animator;
        public float speed = 1;
    }
	public class AnimatorProxyPdr: CmpProvider<AnimatorProxy> { }
}
