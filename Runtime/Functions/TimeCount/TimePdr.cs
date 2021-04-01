using System.Collections.Generic;
using ActionTree;
using UnityEngine;
namespace ActionTree
{
	[System.Serializable]
	public sealed class Time : IComponent
	{
        public float add;
        public float time;
    }
	public class TimePdr: CmpProvider<Time> { }
}
