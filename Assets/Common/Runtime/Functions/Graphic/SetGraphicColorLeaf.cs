namespace ActionTree
{
    [MainThread]
	public sealed class SetGraphicColor:ATree
	{
        GraphicProxy proxy;
        ColorData color;
        [AllowNull]Boolen justAhpla;
		public override void Do()
        {
            if (justAhpla.Value(false))
            {
                var a = proxy.value.color;
                a.a = color.value.a;
                proxy.value.color = a;
            }
            else
            {
                proxy.value.color = color.value;
            }
            Condition = true;
        }
	}
	public class SetGraphicColorLeaf: TreeProvider<SetGraphicColor> { }
}
