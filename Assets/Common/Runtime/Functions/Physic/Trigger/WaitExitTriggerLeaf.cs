using ActionTree;
using UnityEngine;
namespace ActionTree
{
    public sealed class WaitExitTrigger : ATree
    {
        UnityTriggerProxy proxy;
        TriggerColiders coliders;
        //[AllowNull] Boolen stopOnFirstEnter;
        bool isInited;
        public override void Do()
        {
            Condition = coliders.colliders.Count > 0;
            //Debug.Log(coliders.colliders.Count);
            if (isInited) return;
            isInited = true;
            proxy.trigger.onTriggerExit += OnTriggerExit;
        }

        private void OnTriggerExit(Collider obj)
        {
            //this.Log($" trigger exit {obj}");
            //Condition = true;
            //if (stopOnFirstEnter.Value(false))
            //    proxy.trigger.onTriggerExit -= OnTriggerExit;
            coliders.colliders.Add(obj);
        }
        public override void Clear()
        {
            base.Clear();
            //if (stopOnFirstEnter.Value(false))
            //    isInited = false;
            coliders.colliders.Clear();
        }
    }
	public class WaitExitTriggerLeaf: TreeProvider<WaitExitTrigger> { }
}
