using System;
using System.Collections.Generic;
using ActionTree;
using UnityEngine;
namespace ActionTree
{
	[Serializable]
	public sealed class Format : IComponent
	{
        static readonly object[] empty = new object[0];
        public string value;
        [HideInInspector] public object[] param = empty;
        public object this[int index]
        {
            set
            {
                if (index >= param.Length)
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
