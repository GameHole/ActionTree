using System.Collections.Generic;
using ActionTree;
using UnityEngine;
namespace ActionTree
{
	[System.Serializable]
	public sealed class Process : FloatValue { }
	public class ProcessPdr: CmpProvider<Process> { }
}
