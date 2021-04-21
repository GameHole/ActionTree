using ActionTree;
using UnityEngine;
namespace ActionTree
{
	public abstract class WaitBoolen<T>:ATree where T:Boolen
	{
        protected T target;
		public override void Do()
        {
            Condition = target.value;
        }
        public override void Clear()
        {
            base.Clear();
            target.value = false;
        }
    }
}
