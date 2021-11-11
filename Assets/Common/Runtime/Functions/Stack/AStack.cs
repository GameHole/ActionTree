using System.Collections.Generic;
using ActionTree;
using UnityEngine;
namespace ActionTree
{
	//[System.Serializable]
	public class AStack<T> : IComponent
	{
        public Stack<T> value = new Stack<T>();
	}
}
