using System.Collections.Generic;
using ActionTree;
using UnityEngine;
namespace ActionTree
{
	[System.Serializable]
	public sealed class AudioProxy : IComponent
	{
        public AudioSource source;
	}
	public class AudioProxyPdr: CmpProvider<AudioProxy> { }
}
