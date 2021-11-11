using ActionTree;
using System;
using UnityEngine;
namespace ActionTree
{
	public sealed class LoadConfigField:ATree
	{
        ConfigType type;
        ConfigField field;
        ConfigFieldValue output;
        IntValue index;
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
                    var v = cmp.Get(index);
                    output.value = field.info.GetValue(v);
                    Condition = true;
                }
            }
        }
	}
	public class LoadConfigFieldLeaf: TreeProvider<LoadConfigField> { }
}
