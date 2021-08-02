using System.Collections.Generic;
using ActionTree;
using UnityEngine;
namespace ActionTree
{
	[System.Serializable]
	public sealed class FontProxy : IComponent
	{
        public Font value;
	}
	public class FontProxyPdr: CmpProvider<FontProxy> { }
}
