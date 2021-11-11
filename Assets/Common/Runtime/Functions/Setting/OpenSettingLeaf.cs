using ActionTree;
using UnityEngine;
namespace ActionTree
{
    [MainThread]
    public sealed class OpenSetting : ATree
    {
        GameObject setting;
        [Finded(typeof(SettingCanvasMark))] GameObjectProxy proxy;
        public override void Do()
        {
            proxy.target.SetActive(true);
            Condition = true;
        }
    }
	public class OpenSettingLeaf: TreeProvider<OpenSetting> { }
}
