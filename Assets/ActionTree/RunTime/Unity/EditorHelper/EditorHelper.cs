using System.Collections.Generic;
using UnityEngine;

namespace ActionTree
{
#if UNITY_EDITOR
    public static class EditorHelper
	{
        public static int Popup(int selectIndex,string[] contexts,string name,int nameWidth=180,int popWidth=300)
        {
            UnityEditor.EditorGUILayout.BeginHorizontal();
            UnityEditor.EditorGUILayout.LabelField(name, GUILayout.Width(nameWidth));
            int last = UnityEditor.EditorGUILayout.Popup(selectIndex, contexts, GUILayout.Width(popWidth));
            UnityEditor.EditorGUILayout.EndHorizontal();
            return last;
        }
	}
#endif
}
