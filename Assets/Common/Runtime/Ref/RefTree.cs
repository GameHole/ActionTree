using ActionTree;
using UnityEngine;
namespace ActionTree
{
	public class RefTree<T>:ATree where T:class,IComponent
	{
        [Finded] protected T cmp;
		public override void Do()
        {
            entity.Set(cmp);
            ReApply();
            Condition = true;
        }
	}
    public class RefTree<T1,T2> : ATree 
        where T1 : class, IComponent
        where T2 : class, IComponent
    {
        [Finded] protected T1 cmp1;
        [Finded] protected T2 cmp2;
        public override void Do()
        {
            entity.Set(cmp1);
            entity.Set(cmp2);
            ReApply();
            Condition = true;
        }
    }
    public class RefTree<T1, T2,T3> : ATree
        where T1 : class, IComponent
        where T2 : class, IComponent
        where T3 : class, IComponent
    {
        [Finded] protected T1 cmp1;
        [Finded] protected T2 cmp2;
        [Finded] protected T2 cmp3;
        public override void Do()
        {
            entity.Set(cmp1);
            entity.Set(cmp2);
            entity.Set(cmp3);
            ReApply();
            Condition = true;
        }
    }
}
