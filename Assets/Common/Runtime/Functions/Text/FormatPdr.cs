using System;
using System.Collections.Generic;
using ActionTree;
using UnityEngine;
namespace ActionTree
{
	[Serializable]
	public sealed class Format : IComponent
	{
        public string value;
        [HideInInspector] public object[] param;
        public object this[int index]
        {
            set
            {
                if(param == null)
                {
                    param = new object[1];
                }
                else if (index >= param.Length)
                {
                    var newArr = new object[index + 1];
                    Array.Copy(param, newArr, param.Length);
                    param = newArr;
                }
                param[index] = value;
            }
            get
            {
                return param[index];
            }
        }
	}
	public class FormatPdr: CmpProvider<Format> { }
}
