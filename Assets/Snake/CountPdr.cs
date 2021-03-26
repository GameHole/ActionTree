using System.Collections.Generic;
using ActionTree;
using UnityEngine;
namespace Default
{
	[System.Serializable]
	public sealed class Count : IComponent
	{
        public int value;
	}
	public class CountPdr: CmpProvider<Count> { }
}
