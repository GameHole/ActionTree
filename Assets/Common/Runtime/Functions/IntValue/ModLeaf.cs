namespace ActionTree
{
	public sealed class Mod:ATree
	{
        IntValue left;
        IntValue right;
        IntValue outPut;
		public override void Do()
        {
            outPut.value = left % right;
            Condition = true;
        }
	}
	public class ModLeaf: TreeProvider<Mod> { }
}
