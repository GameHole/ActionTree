using ActionTree;
using UnityEngine;
using UnityEngine.UI;

namespace Default
{
    [MainThread]
	[System.Serializable]
	public sealed class WaitButton:ATree
	{
        public Button button;
        bool isInited;
		public override void Do()
        {
            if (isInited) return;
            isInited = true;
            button.onClick.AddListener(onclick);
        }
        void onclick()
        {
            Condition = true;
            button.onClick.RemoveListener(onclick);
        }
        public override void Clear()
        {
            base.Clear();
            isInited = false;
        }
    }
	public class WaitButtonLeaf: TreeProvider<WaitButton> { }
}
