namespace ActionTree
{
    public class CmpRef<T>:IComponent where T:IComponent
    {
        public T refCmp;
    }
    public abstract class CmpRefProvider<T> : CmpProvider where T :class, IComponent,new()
    {
        public CmpProvider<T> provider;
        public override IComponent GetValue()
        {
            return new CmpRef<T>() { refCmp = provider.value };
        }
    }
}

