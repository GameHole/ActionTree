using System;
using System.Collections.Generic;
using System.Reflection;

namespace ActionTree
{
	public static class TreeDomain
	{
        static Assembly[] _workAssemblies;
        public static Assembly[] workAssemblies
        {
            get
            {
                if (_workAssemblies == null)
                    LoadCSharp();
                return _workAssemblies;
            }
        }
        static void LoadCSharp()
        {
            List<Assembly> assemblies = new List<Assembly>();
            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                if (isIgnoredAssembliy(assembly)) continue;
                assemblies.Add(assembly);
            }
            _workAssemblies = assemblies.ToArray();
        }
        static string[] ignoreStr = new string[]
        {
            "mscorlib","UnityEngine","UnityEngine.","UnityEditor","UnityEditor.","Newtonsoft.","SyntaxTree.","ExCSS.","Microsoft.","Unity.","System","System.","Mono.","nunit.","netstandard"
        };
        static bool isIgnoredAssembliy(Assembly assembly)
        {
            for (int i = 0; i < ignoreStr.Length; i++)
            {
                if (assembly.FullName.Contains(ignoreStr[i]))
                    return true;
            }
            return false;
        }
    }
}
