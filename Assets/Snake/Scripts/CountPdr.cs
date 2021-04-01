using System.Collections.Generic;
using ActionTree;
using UnityEngine;
namespace ActionTree
{
	[System.Serializable]
	public sealed class Count : IComponent
	{
        public int value;
	}
	public class CountPdr: CmpProvider<Count> { }
}
