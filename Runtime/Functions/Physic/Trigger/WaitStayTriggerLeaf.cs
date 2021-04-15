using ActionTree;
using UnityEngine;
namespace ActionTree
{
	public sealed class WaitStayTrigger:ATree
	{
        UnityTriggerProxy proxy;
        TriggerColiders coliders;
        bool isInited;
        public override void Do()
        {
            if (isInited) return;
            isInited = true;
            proxy.trigger.onTriggerStay += OnTriggerStay;
        }

        private void OnTriggerStay(Collider obj)
        {
            Condition = true;
            //proxy.trigger.onTriggerEnter -= OnTriggerStay;
            coliders.colliders.Add(obj);
        }

        public override void Clear()
        {
            base.Clear();
            //isInited = false;
            coliders.colliders.Clear();
        }
    }
	public class WaitStayTriggerLeaf: TreeProvider<WaitStayTrigger> { }
}
