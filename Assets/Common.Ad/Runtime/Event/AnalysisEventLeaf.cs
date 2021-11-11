using ActionTree;
using UnityEngine;
using MiniGameSDK;
namespace ActionTree
{
    [MainThread]
	public sealed class AnalysisEvent:ATree
	{
        Key key;
        [AllowNull]ValuesPair values;
		public override void Do()
        {
            var e = RefinterEx.GetShared<IAnalyzeEvent>();
            if (e != null)
            {
                if (values == null || values.kvs.Count==0)
                {
                    e.SetEvent(key.value);
                }
                else
                {
                    e.SetEvent(key.value, values.kvs);
                }
            }
            else
            {
                _Debug();
            }
           
            Condition = true;
        }
        void _Debug()
        {
            string k = key.value + " ";
            if (values != null)
            {
                foreach (var item in values.kvs)
                {
                    k += $"[{item.Key}:{item.Value}],";
                }
            }
            this.Log($"set event {k}");
        }
    }
	public class AnalysisEventLeaf: TreeProvider<AnalysisEvent> { }
}
