using ActionTree;
using UnityEngine;
namespace Default
{
    [System.Serializable]
    public sealed class Speed : IComponent
    {
        public float value;
    }
	public class SpeedPdr: CmpProvider<Speed> { }
}
