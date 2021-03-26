using System.Collections.Generic;
using ActionTree;
using UnityEngine;
using UnityEngine.UI;

namespace Default
{
	[System.Serializable]
	public sealed class ButtonProxy : IComponent
	{
        public Button button;
	}
	public class ButtonProxyPdr: CmpProvider<ButtonProxy> { }
}
