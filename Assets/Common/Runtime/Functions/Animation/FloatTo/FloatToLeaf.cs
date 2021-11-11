namespace ActionTree
{
    public sealed class FloatTo:ATree
	{
        FloatValue value;
        FloatToData data;
        FloatValue draveData;
		public override void Do()
        {
            float dir = data.useDir ? data.dir : data.end - data.start;
            value.value = data.start + draveData * dir;
        }
    }
	public class FloatToLeaf: TreeProvider<FloatTo> { }
}
