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
        //public override void Clear()
        //{
        //    base.Clear();
        //    target.value = false;
        //}
    }
    public class WaitBoolen : WaitBoolen<Boolen> { }
    public class WaitBoolenLeaf : TreeProvider<WaitBoolen> { }
    //[MainThread]
    //public abstract class ClearBoolen<T> : ATree where T : Boolen
    //{
    //    protected T target;
    //    public override void Do()
    //    {
    //        target.value = false;
    //        //driver.postMains.Enqueue(() =>
    //        //{
    //        //    target.value = false;
    //        //});
    //        Condition = true;
    //    }
    //}
}
