using System.Collections.Generic;
using ActionTree;
using UnityEngine;
namespace ActionTree
{
    [FileName("AATE")]
	public sealed class AAA : IConfigValue
	{
        public string a;
	}
	public class AAAPdr: ConfigProxyPdr<AAA> { }
}
