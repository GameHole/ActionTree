using System.Collections.Generic;
using ActionTree;
using UnityEngine;
using UnityEngine.UI;

namespace ActionTree
{
	[System.Serializable]
	public sealed class TextProxy : IComponent
	{
        public Text value;
	}
	public class TextProxyPdr: CmpProvider<TextProxy> { }
}
