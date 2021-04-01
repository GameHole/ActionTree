using System.Collections.Generic;
using ActionTree;
using UnityEngine;
using UnityEngine.UI;

namespace ActionTree
{
	[System.Serializable]
	public sealed class ButtonProxy : IComponent
	{
        public Button button;
	}
	public class ButtonProxyPdr: CmpProvider<ButtonProxy> { }
}
