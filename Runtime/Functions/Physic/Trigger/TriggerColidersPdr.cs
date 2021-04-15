using System.Collections.Generic;
using ActionTree;
using UnityEngine;
namespace ActionTree
{
	//[System.Serializable]
	public sealed class TriggerColiders : IComponent
	{
        public List<Collider> colliders = new List<Collider>();
        public Collider this[int index]
        {
            get
            {
                return colliders[index];
            }
        }
        public int Count => colliders.Count;
	}
	public class TriggerColidersPdr: CmpProvider<TriggerColiders> { }
}
