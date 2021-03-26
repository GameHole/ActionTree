using ActionTree;
using UnityEngine;
using UnityEngine.UI;

namespace Default
{
    [MainThread]
	public sealed class WaitButton:ATree
	{
        ButtonProxy proxy;
        bool isInited;
		public override void Do()
        {
            if (isInited) return;
            isInited = true;
            proxy.button.onClick.AddListener(onclick);
        }
        void onclick()
        {
            Condition = true;
            proxy.button.onClick.RemoveListener(onclick);
        }
        public override void Clear()
        {
            base.Clear();
            isInited = false;
        }
    }
	public class WaitButtonLeaf: TreeProvider<WaitButton> { }
}
