using UnityEngine;
namespace ActionTree
{
    [System.Serializable]
	public sealed class AnimCurve : IComponent
	{
        public AnimationCurve curve;
        public bool useCurve;
        public Vector2 increaseRange = new Vector2(0, 1);
        public float increase;
        public float output;
    }
	public class AnimCurvePdr: CmpProvider<AnimCurve> { }
}
