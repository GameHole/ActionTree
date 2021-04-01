using ActionTree;
using UnityEngine;
namespace ActionTree
{
	//[System.Serializable]
	public sealed class PreRotation : IComponent
	{
        public Queue<Quaternion> rotateions = new Queue<Quaternion>();
	}
	public class PreRotationPdr: CmpProvider<PreRotation> { }
}
