using System.Collections.Generic;
using ActionTree;
using UnityEngine;
namespace ActionTree
{
	[System.Serializable]
	public sealed class Process : IComponent
	{
        public float value;
	}
	public class ProcessPdr: CmpProvider<Process> { }
}
