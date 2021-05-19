using System.Collections.Generic;
using ActionTree;
using UnityEngine;
namespace ActionTree
{
	[System.Serializable]
	public sealed class StringValue : IComponent
	{
        public string value;
	}
	public class StringValuePdr: CmpProvider<StringValue> { }
}
