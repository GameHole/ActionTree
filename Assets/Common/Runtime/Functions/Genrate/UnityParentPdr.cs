using System.Collections.Generic;
using ActionTree;
using UnityEngine;
namespace ActionTree
{
	[System.Serializable]
	public sealed class UnityParent : IComponent
	{
        public Transform value;
	}
	public class UnityParentPdr : CmpProvider<UnityParent>
    {
        public bool useCurrentParent;
        public override IComponent GetValue()
        {
            if (useCurrentParent)
                value.value = transform.parent;
            return base.GetValue();
        }
    }
}
