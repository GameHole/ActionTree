using UnityEngine;
using UnityEditor;
using System.IO;
using UnityEditor.ProjectWindowCallback;
using System.Text.RegularExpressions;
using System.Text;
[InitializeOnLoad]
public class ConfigCmpEditor : MonoBehaviour
{
    [MenuItem("Assets/Create/ActionTree/Config Component Provider", false, 100)]
    public static void CreateCmpProviderScript()
    {
        var path = AssetDatabase.GUIDToAssetPath("78d38334a67237840ac1edb0e9acb6a6");
        ProjectWindowUtil.StartNameEditingIfProjectWindowExists(0,
        ScriptableObject.CreateInstance<MyDoCreateAdaptorScriptAsset>(),
        GetSelectedPathOrFallback() + "/NewConfigValuePdr.cs", null, path);
    }
    public static string GetSelectedPathOrFallback()
    {
        string path = "Assets";
        foreach (Object obj in Selection.GetFiltered< Object >(SelectionMode.Assets))
        {
            path = AssetDatabase.GetAssetPath(obj);
            if (!string.IsNullOrEmpty(path) && File.Exists(path))
            {
                path = Path.GetDirectoryName(path);
                break;
            }
        }
        return path;
    }
}


class MyDoCreateScriptAsset : EndNameEditAction
{
    public override void Action(int instanceId, string pathName, string resourceFile)
    {
        Object o = CreateScriptAssetFromTemplate(pathName, resourceFile);
        ProjectWindowUtil.ShowCreatedAsset(o);
    }

    internal static Object CreateScriptAssetFromTemplate(string pathName, string resourceFile)
    {
        Debug.Log("aaa");
        string fullPath = Path.GetFullPath(pathName);
        //StreamReader streamReader = new StreamReader(resourceFile);
        string text = File.ReadAllText(resourceFile);// streamReader.ReadToEnd();
        
        //streamReader.Close();
        string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(pathName);
        text = Regex.Replace(text, "#NAME#", fileNameWithoutExtension);
        text = Regex.Replace(text, "#NAMESPACE#", EntitiesEditor.nameSpace);
        
        bool encoderShouldEmitUTF8Identifier = true;
        bool throwOnInvalidBytes = false;
        UTF8Encoding encoding = new UTF8Encoding(encoderShouldEmitUTF8Identifier, throwOnInvalidBytes);
        bool append = false;
        StreamWriter streamWriter = new StreamWriter(fullPath, append, encoding);
        streamWriter.Write(text);
        streamWriter.Close();
        
        AssetDatabase.ImportAsset(pathName);
        
        return AssetDatabase.LoadAssetAtPath(pathName, typeof(Object));
    }
}
class MyDoCreateAdaptorScriptAsset : EndNameEditAction
{
    public override void Action(int instanceId, string pathName, string resourceFile)
    {
        Object o = CreateScriptAssetFromTemplate(pathName, resourceFile);
        ProjectWindowUtil.ShowCreatedAsset(o);
    }

    internal static Object CreateScriptAssetFromTemplate(string pathName, string resourceFile)
    {

        string fullPath = Path.GetFullPath(pathName);
        fullPath = fullPath.Replace(".cs", "Pdr.cs");
        string edttorPath = AssetDatabase.GUIDToAssetPath("ace8437cafda4404bafdf89c079ddbd1");
        string edttorTxt = File.ReadAllText(edttorPath);
        //StreamReader streamReader = new StreamReader(resourceFile);
        string text = File.ReadAllText(resourceFile);// streamReader.ReadToEnd();
        //streamReader.Close();
        string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(pathName);
        text = Regex.Replace(text, "#NAME#", fileNameWithoutExtension);
        text = Regex.Replace(text, "#NAMESPACE#", EntitiesEditor.nameSpace);
        edttorTxt = Regex.Replace(edttorTxt, "#NAME#", fileNameWithoutExtension);
        edttorTxt = Regex.Replace(edttorTxt, "#NAMESPACE#", EntitiesEditor.nameSpace);
        pathName = pathName.Replace(".cs", "Pdr.cs");
        bool encoderShouldEmitUTF8Identifier = true;
        bool throwOnInvalidBytes = false;
        UTF8Encoding encoding = new UTF8Encoding(encoderShouldEmitUTF8Identifier, throwOnInvalidBytes);
        bool append = false;
        StreamWriter streamWriter = new StreamWriter(fullPath, append, encoding);
        streamWriter.Write(text);
        streamWriter.Close();
        string editorOutPath = "Assets/Editor/ConfigEditorEx";
        if (!Directory.Exists(editorOutPath))
        {
            Directory.CreateDirectory(editorOutPath);
        }
        string editorOutFilePath = Path.Combine(editorOutPath, $"{fileNameWithoutExtension}EditorEx.cs");
        streamWriter = new StreamWriter(editorOutFilePath, append, encoding);
        streamWriter.Write(edttorTxt);
        streamWriter.Close();
        AssetDatabase.ImportAsset(pathName);
        AssetDatabase.ImportAsset(editorOutFilePath);
        return AssetDatabase.LoadAssetAtPath(pathName, typeof(Object));
    }
}