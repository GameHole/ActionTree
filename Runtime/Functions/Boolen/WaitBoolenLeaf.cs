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
    }
    public abstract class ClearBoolen<T> : ATree where T : Boolen
    {
        protected T target;
        public override void Do()
        {
            driver.postMains.Enqueue(() =>
            {
                target.value = false;
            });
            Condition = true;
        }
    }
}
