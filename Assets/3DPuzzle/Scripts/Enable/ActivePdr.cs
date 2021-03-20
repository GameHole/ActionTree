using System.Collections.Generic;
using ActionTree;
using UnityEngine;
namespace Default
{
	[System.Serializable]
	public sealed class Active : IComponent
	{
        public bool value = true;
	}
	public class ActivePdr: CmpProvider<Active> { }
}
