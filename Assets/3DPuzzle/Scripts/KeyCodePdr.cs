using System.Collections.Generic;
using ActionTree;
using UnityEngine;
namespace Default
{
	[System.Serializable]
	public sealed class KeyCode : IComponent
	{
        public UnityEngine.KeyCode code;
	}
	public class KeyCodePdr: CmpProvider<KeyCode> { }
}
