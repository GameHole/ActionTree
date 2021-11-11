using System.Collections.Generic;
using ActionTree;
using UnityEngine;
namespace ActionTree
{
	[System.Serializable]
	public sealed class AudioCollector : IComponent
	{
        public List<AudioSource> audios = new List<AudioSource>();
        public bool isMute;
	}
	public class AudioCollectorPdr: CmpProvider<AudioCollector> { }
}
