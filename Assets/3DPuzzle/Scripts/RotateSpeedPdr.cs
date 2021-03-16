using System.Collections.Generic;
using ActionTree;
using UnityEngine;
namespace Default
{
	[System.Serializable]
	public sealed class RotateSpeed : IComponent
	{
        public float speed = 10;
        public Vector3 axis = Vector3.up;
	}
	public class RotateSpeedPdr: CmpProvider<RotateSpeed> { }
}
