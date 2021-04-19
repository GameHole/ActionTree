using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
namespace ActionTree
{
    public class AAAEditorEx
    {
        [MenuItem("CONTEXT/AAAPdr/GenrateFile")]
        static void AA()
        {
            ConfigExcelGenrater.GenrateExcel(Selection.activeGameObject.GetComponent<AAAPdr>().GetElementType());
        }
    }
}

