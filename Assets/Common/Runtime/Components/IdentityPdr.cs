using System.Collections.Generic;
using ActionTree;
using UnityEngine;
namespace ActionTree
{
    [System.Serializable]
    public sealed class Identity : IntValue
    {
        //public int value;
    }
    public class IdentityPdr : CmpProvider<Identity> { }
}
