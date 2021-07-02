using System.Collections.Generic;
using ActionTree;
using UnityEngine;
namespace ActionTree
{
	[System.Serializable]
	public sealed class CameraProxy : IComponent
	{
        public Camera value;
	}
	public class CameraProxyPdr: CmpProvider<CameraProxy> { }
}
