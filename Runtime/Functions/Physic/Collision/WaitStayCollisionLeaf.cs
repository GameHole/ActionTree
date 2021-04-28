using ActionTree;
using UnityEngine;
namespace ActionTree
{
	public sealed class WaitStayCollision : ATree
	{
        UnityTriggerProxy proxy;
        Collisions coliders;
        bool isInited;
        public override void Do()
        {
            if (isInited) return;
            isInited = true;
            proxy.trigger.onCollisionStay += OnTriggerStay;
        }

        private void OnTriggerStay(Collision obj)
        {
            Condition = true;
            //proxy.trigger.onTriggerEnter -= OnTriggerStay;
            coliders.collisions.Add(obj);
        }

        public override void Clear()
        {
            base.Clear();
            //isInited = false;
            coliders.collisions.Clear();
        }
    }
	public class WaitStayCollisionLeaf : TreeProvider<WaitStayCollision> { }
}
