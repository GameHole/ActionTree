namespace ActionTree
{
    [MainThread]
    public sealed class SetFont:ATree
	{
        TextProxy proxy;
        FontProxy fontProxy;
        public override void Do()
        {
            proxy.value.font = fontProxy.value;
            Condition = true;
        }
	}
	public class SetFontLeaf: TreeProvider<SetFont> { }
}
