using ActionTree;
using UnityEngine;
namespace ActionTree
{
	public class Push<T>:ATree
	{
        protected AStack<T> stack;
        protected Value<T> value;
		public override void Do()
        {
            //this.Log(stack);
            stack.value.Push(value.value);
            Condition = true;
        }
	}
    public class Pop<T> : ATree
    {
        protected AStack<T> stack;
        protected Value<T> value;
        public override void Do()
        {
            value.value = stack.value.Pop();
            Condition = true;
        }
    }
}
