using ActionTree;
using UnityEngine;
namespace ActionTree
{
	public sealed class TestCmpUse:ATree
	{
        TestCmp testField;
		public override void Do()
        {
            //可以直接计算
            float v = testField.testData1;
            this.Log(v + GetTestData());
            Condition = true;
            throw new System.NullReferenceException();
        }
        //可以使用其他方法计算
        float GetTestData()
        {
            return testField.testData1 + testField.testData2;
        }
	}
	public class TestCmpUseLeaf: TreeProvider<TestCmpUse> { }
}
