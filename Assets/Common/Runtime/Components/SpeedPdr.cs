using ActionTree;
using UnityEngine;
namespace ActionTree
{
    [System.Serializable]
    public sealed class Speed : IComponent
    {
        public float value;
    }
	public class SpeedPdr: CmpProvider<Speed> { }
    public static class SpeedEx
    {
        public static float Speed(this Speed speedCmp)
        {
            float speed = 0;
            if (speedCmp != null)
                speed = speedCmp.value;
            return speed;
        }
    }
}
