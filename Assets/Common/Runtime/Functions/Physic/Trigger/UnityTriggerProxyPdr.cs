using System.Collections.Generic;
using ActionTree;
using UnityEngine;
namespace ActionTree
{
	[System.Serializable]
	public sealed class UnityTriggerProxy : IComponent
	{
        public UnityTrigger trigger;
	}
	public class UnityTriggerProxyPdr: CmpProvider<UnityTriggerProxy> { }
}
