using System.Collections.Generic;
using ActionTree;
using UnityEngine;
namespace ActionTree
{
    [FileName("测试文件")]
	public sealed class CCC : IConfigValue
	{
        public int aaa;
        public string bb;
        public int[] cc;
        public float a;
        public float[] dd;
        public double ff;
        public string[] dasdad;
        //public double adsasd;
        public void debug()
        {
            Debug.Log("----start----");
            Debug.Log($"int {aaa}");
            Debug.Log($"string {bb}");
            for (int i = 0; i < cc.Length; i++)
            {
                Debug.Log($"int array {i} = {cc[i]}");
            }
            Debug.Log($"float {a}"); 
            for (int i = 0; i < dd.Length; i++)
            {
                Debug.Log($"float arrat {i} = {dd[i]}");
            }
            Debug.Log($"double {ff}");
            for (int i = 0; i < dasdad.Length; i++)
            {
                Debug.Log($"string array {i} = {dasdad[i]}");
            }
            Debug.Log("----end----\n");
        }
    }
	public class CCCPdr: ConfigProxyPdr<CCC> { }
}
