using System.Collections.Generic;
using ActionTree;
using UnityEngine;
namespace ActionTree
{
	[System.Serializable]
	public sealed class State : IntValue { }
	public class StatePdr: CmpProvider<State> { }
}
