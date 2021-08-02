using ActionTree;
namespace ActionTree
{
	public sealed class TimeToProcess:ATree
	{
        [AllowNull]Boolen isInverse;
        Time time;
        Process process;
		public override void Do()
        {
            float p = time.add / time.time;
            if (isInverse.Value(false))
            {
                p = 1 - p;
            }
            process.value = p;
            Condition = true;
        }
	}
	public class TimeToProcessLeaf: TreeProvider<TimeToProcess> { }
}
