using System.Collections.Generic;
using ActionTree;
using UnityEngine;
namespace ActionTree
{
	public sealed class ValuesPair : IComponent
	{
        public Dictionary<string, string> kvs = new Dictionary<string, string>();
	}
	public class ValuesPairPdr: CmpProvider<ValuesPair> { }
}
