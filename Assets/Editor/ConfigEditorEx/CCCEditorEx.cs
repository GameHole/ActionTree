using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
namespace ActionTree
{
    public class CCCEditorEx
    {
        [MenuItem("CONTEXT/CCCPdr/GenrateFile")]
        static void AA()
        {
            ConfigExcelGenrater.GenrateExcel(Selection.activeGameObject.GetComponent<CCCPdr>().GetElementType());
        }
    }
}

