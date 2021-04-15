using ActionTree;
using UnityEngine;
namespace ActionTree
{
	public sealed class WaitEnterTrigger:ATree
	{
        UnityTriggerProxy proxy;
        TriggerColiders coliders;
        bool isInited;
		public override void Do()
        {
            if (isInited) return;
            isInited = true;
            proxy.trigger.onTriggerEnter += OnTriggerEnter;
        }

        private void OnTriggerEnter(Collider obj)
        {
            Condition = true;
            proxy.trigger.onTriggerEnter -= OnTriggerEnter;
            coliders.colliders.Add(obj);
        }

        public override void Clear()
        {
            base.Clear();
            isInited = false;
            coliders.colliders.Clear();
        }
    }
	public class WaitEnterTriggerLeaf: TreeProvider<WaitEnterTrigger> { }
}
