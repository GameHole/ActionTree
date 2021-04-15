using ActionTree;
using UnityEngine;
namespace ActionTree
{
	public sealed class WaitExitTrigger:ATree
	{
        UnityTriggerProxy proxy;
        TriggerColiders coliders;
        bool isInited;
        public override void Do()
        {
            if (isInited) return;
            isInited = true;
            proxy.trigger.onTriggerExit += OnTriggerExit;
        }

        private void OnTriggerExit(Collider obj)
        {
            Condition = true;
            proxy.trigger.onTriggerExit -= OnTriggerExit;
            coliders.colliders.Add(obj);
        }

        public override void Clear()
        {
            base.Clear();
            isInited = false;
            coliders.colliders.Clear();
        }
    }
	public class WaitExitTriggerLeaf: TreeProvider<WaitExitTrigger> { }
}
