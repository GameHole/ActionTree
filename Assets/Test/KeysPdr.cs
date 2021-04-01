using ActionTree;
using UnityEngine;
using System.Collections.Generic;
namespace ActionTree
{
	[System.Serializable]
	public sealed class Keys : IComponent
	{
        public Dictionary<KeyCode, bool> pressed = new Dictionary<KeyCode, bool>();
	}
	public class KeysPdr: CmpProvider<Keys> { }
}
