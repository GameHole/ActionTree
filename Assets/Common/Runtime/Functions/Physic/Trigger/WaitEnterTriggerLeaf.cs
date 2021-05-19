using ActionTree;
using UnityEngine;
namespace ActionTree
{
	public sealed class WaitEnterTrigger:ATree
	{
        UnityTriggerProxy proxy;
        TriggerColiders coliders;
        //[AllowNull] Boolen stopOnFirstEnter;
        bool isInited;
		public override void Do()
        {
            Condition = coliders.Count > 0;
            //this.Log($" trigger enter count {coliders.Count}");
            if (isInited) return;
            isInited = true;
            proxy.trigger.onTriggerEnter += OnTriggerEnter;
        }

        private void OnTriggerEnter(Collider obj)
        {
            //this.Log($" trigger enter {obj}");
            //Condition = true;
            //if (stopOnFirstEnter.Value(false))
            //    proxy.trigger.onTriggerEnter -= OnTriggerEnter;
            coliders.colliders.Add(obj);
        }

        public override void Clear()
        {
            //Debug.Log(" trigger clear ");
            base.Clear();
            //if (stopOnFirstEnter.Value(false))
            //    isInited = false;
            coliders.colliders.Clear();
        }
    }
	public class WaitEnterTriggerLeaf: TreeProvider<WaitEnterTrigger> { }
}
