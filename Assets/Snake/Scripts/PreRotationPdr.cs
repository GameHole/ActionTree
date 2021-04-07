using ActionTree;
using UnityEngine;
namespace ActionTree
{
	//[System.Serializable]
	public sealed class PreRotation : IComponent
	{
        public MyQueue<Quaternion> rotateions = new MyQueue<Quaternion>();
	}
	public class PreRotationPdr: CmpProvider<PreRotation> { }
}
