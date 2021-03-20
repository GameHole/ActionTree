﻿using ActionTree;
using UnityEngine;
namespace Default
{
	//[System.Serializable]
	public sealed class WaitSelect:ATree
	{
        SelectId id;
        CombinedUICntr cntr;
        public override void Do()
        {
            if(Entity.driver.TryFindFirstCmp(ref cntr))
            {
                for (int i = 0; i < cntr.clicks.Count; i++)
                {
                    if (cntr.clicks[i].isEnter)
                    {
                        Condition = true;
                        id.value = i;
                        break;
                    }
                }
            }
        }
        public override void Clear()
        {
            base.Clear();
            if (Entity.driver.TryFindFirstCmp(ref cntr))
            {
                for (int i = 0; i < cntr.clicks.Count; i++)
                {
                    cntr.clicks[i].isEnter = false;
                }
            }
        }
    }
	public class WaitSelectLeaf: TreeProvider<WaitSelect> { }
}
