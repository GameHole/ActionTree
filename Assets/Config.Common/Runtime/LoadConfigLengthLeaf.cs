using ActionTree;
using System;
using UnityEngine;
namespace ActionTree
{
	public sealed class LoadConfigLength:ATree
	{
        ConfigType type;
        IntValue output;
        Type catche;
        Entity ec;
        public override void Do()
        {
            if (catche == null)
            {
                catche = typeof(Config<>).MakeGenericType(type.type);
            }
            if (driver.TryFindEntityWith(ref ec, catche))
            {
                var cmp = ec.Get(catche) as AConfig;
                if (cmp.isInitialized())
                {
                    
                    output.value = cmp.Length;
                    //Debug.Log($"{catche}::{output}");a
                    Condition = true;
                }
            }
        }
	}
	public class LoadConfigLengthLeaf: TreeProvider<LoadConfigLength> { }
}
