using System.Collections.Generic;
using ActionTree;
using UnityEngine;
namespace ActionTree
{
	[System.Serializable]
	public sealed class KeyCode : IComponent
	{
        public UnityEngine.KeyCode code;
	}
	public class KeyCodePdr: CmpProvider<KeyCode> { }
}
