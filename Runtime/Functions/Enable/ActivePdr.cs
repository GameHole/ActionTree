using System.Collections.Generic;
using ActionTree;
using UnityEngine;
namespace ActionTree
{
	[System.Serializable]
	public sealed class Active : IComponent
	{
        public bool value = true;
	}
	public class ActivePdr: CmpProvider<Active> { }
}
