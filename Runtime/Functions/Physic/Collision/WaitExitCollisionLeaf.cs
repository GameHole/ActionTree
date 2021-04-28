using ActionTree;
using UnityEngine;
namespace ActionTree
{
	public sealed class WaitExitCollision : ATree
	{
        UnityTriggerProxy proxy;
        Collisions coliders;
        bool isInited;
        public override void Do()
        {
            if (isInited) return;
            isInited = true;
            proxy.trigger.onCollisionExit += OnTriggerExit;
        }

        private void OnTriggerExit(Collision obj)
        {
            Condition = true;
            //proxy.trigger.onCollisionExit -= OnTriggerExit;
            coliders.collisions.Add(obj);
        }

        public override void Clear()
        {
            base.Clear();
            //isInited = false;
            coliders.collisions.Clear();
        }
    }
	public class WaitExitCollisionLeaf : TreeProvider<WaitExitCollision> { }
}
