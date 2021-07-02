namespace ActionTree
{
	public sealed class IsTimeOver:ATree
	{
        Time time;
		public override void Do()
        {
            Condition = time.add >= time.time;   
        }
	}
	public class IsTimeOverLeaf: TreeProvider<IsTimeOver> { }
}
