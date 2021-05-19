using System.Collections.Generic;
using ActionTree;
using UnityEngine;
namespace ActionTree
{
	//[System.Serializable]
	public sealed class LoadAsyncParam : IComponent
	{
        public AsyncOperation operation;
	}
	public class LoadAsyncParamPdr: CmpProvider<LoadAsyncParam> { }
}
