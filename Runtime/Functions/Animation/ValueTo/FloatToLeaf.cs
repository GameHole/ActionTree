namespace ActionTree
{
    public sealed class FloatTo:ATree
	{
        FloatValue value;
        FloatToData data;
        AnimCurve curve;
		public override void Do()
        {
            float dir = data.useDir ? data.dir : data.end - data.start;
            value.value = data.start + curve.output * dir;
        }
    }
	public class FloatToLeaf: TreeProvider<FloatTo> { }
}
