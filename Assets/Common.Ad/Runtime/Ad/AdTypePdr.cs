using System.Collections.Generic;
using ActionTree;
using UnityEngine;
namespace ActionTree
{
	[System.Serializable]
	public sealed class AdType : IComponent
	{
		public enum AdTypeEnum
        {
            Reward, Interstitial,Banner
        }
        public AdTypeEnum type;
	}
	public class AdTypePdr: CmpProvider<AdType> { }
}
