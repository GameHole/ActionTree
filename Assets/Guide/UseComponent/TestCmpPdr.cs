using System.Collections.Generic;
using ActionTree;
using UnityEngine;
namespace ActionTree
{
	[System.Serializable]
	public sealed class TestCmp : IComponent
	{
        public int testData1;
        public float testData2;
        public int GetTestData() => testData1;//可以添加访问数据的辅助方法,但一般没有必要

        //public float CaculateTestAA() => testData2 + testData1*2; //不允许添加任何逻辑相关代码
    }
    public class TestCmpPdr: CmpProvider<TestCmp> { }
}
