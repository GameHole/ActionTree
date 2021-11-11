using System;
using System.Collections.Generic;
using ActionTree;
using UnityEngine;
namespace ActionTree
{
	[System.Serializable]
	public sealed class QualityIndexs : IComponent
	{
        public enum Quality
        {
            VeryLow, Low, Medium,High, VeryHigh,Ultra
        }
        public Quality[] indexs;
	}
	public class QualityIndexsPdr: CmpProvider<QualityIndexs> { }
}
