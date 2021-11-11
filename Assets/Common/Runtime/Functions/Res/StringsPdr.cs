using System.Collections.Generic;
using ActionTree;
using UnityEngine;
namespace ActionTree
{
	[System.Serializable]
	public sealed class Strings : Array<string> { }
	public class StringsPdr: CmpProvider<Strings> { }
}
