using ActionTree;
using UnityEngine;
namespace ActionTree
{
	public sealed class WaitEnterCollision : ATree
	{
        UnityTriggerProxy proxy;
        Collisions coliders;
        bool isInited;
		public override void Do()
        {
            Condition = coliders.collisions.Count > 0;
            if (isInited) return;
            isInited = true;
            proxy.trigger.onCollisionEnter += OnTriggerEnter;
        }

        private void OnTriggerEnter(Collision obj)
        {
            //this.Log(obj);
            //proxy.trigger.onCollisionEnter -= OnTriggerEnter;
            coliders.collisions.Add(obj);
        }

        public override void Clear()
        {
            base.Clear();
            //isInited = false;
            coliders.collisions.Clear();
        }
    }
	public class WaitEnterCollisionLeaf : TreeProvider<WaitEnterCollision> { }
}
