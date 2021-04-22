using UnityEngine;
using UnityEditor;
using System.IO;
using UnityEditor.ProjectWindowCallback;
using System.Text.RegularExpressions;
using System.Text;
[InitializeOnLoad]
public class BoolenEditor : MonoBehaviour
{
    [MenuItem("Assets/Create/ActionTree/Boolen With Provider", false, 50)]
    public static void CreateCmpProviderScript()
    {
        var path = AssetDatabase.GUIDToAssetPath("52e99ce518883a64794da22a0c196ce4");
        ProjectWindowUtil.StartNameEditingIfProjectWindowExists(0,
        ScriptableObject.CreateInstance<MyDoCreateAdaptorScriptAsset>(),
        GetSelectedPathOrFallback() + "/NewBoolenPdr.cs", null, path);
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


//class MyDoCreateScriptAsset : EndNameEditAction
//{
//    public override void Action(int instanceId, string pathName, string resourceFile)
//    {
//        Object o = CreateScriptAssetFromTemplate(pathName, resourceFile);
//        ProjectWindowUtil.ShowCreatedAsset(o);
//    }

//    internal static Object CreateScriptAssetFromTemplate(string pathName, string resourceFile)
//    {
       
//        string fullPath = Path.GetFullPath(pathName);
//        //StreamReader streamReader = new StreamReader(resourceFile);
//        string text = File.ReadAllText(resourceFile);// streamReader.ReadToEnd();
//        //streamReader.Close();
//        string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(pathName);
//        text = Regex.Replace(text, "#NAME#", fileNameWithoutExtension);
//        text = Regex.Replace(text, "#NAMESPACE#", EntitiesEditor.nameSpace);
//        bool encoderShouldEmitUTF8Identifier = true;
//        bool throwOnInvalidBytes = false;
//        UTF8Encoding encoding = new UTF8Encoding(encoderShouldEmitUTF8Identifier, throwOnInvalidBytes);
//        bool append = false;
//        StreamWriter streamWriter = new StreamWriter(fullPath, append, encoding);
//        streamWriter.Write(text);
//        streamWriter.Close();
//        AssetDatabase.ImportAsset(pathName);
//        return AssetDatabase.LoadAssetAtPath(pathName, typeof(Object));
//    }
//}
//class MyDoCreateLeafScriptAsset : EndNameEditAction
//{
//    public override void Action(int instanceId, string pathName, string resourceFile)
//    {
//        Object o = CreateScriptAssetFromTemplate(pathName, resourceFile);
//        ProjectWindowUtil.ShowCreatedAsset(o);
//    }

//    internal static Object CreateScriptAssetFromTemplate(string pathName, string resourceFile)
//    {

//        string fullPath = Path.GetFullPath(pathName);
//        fullPath = fullPath.Replace(".cs", "Leaf.cs");
//        //StreamReader streamReader = new StreamReader(resourceFile);
//        string text = File.ReadAllText(resourceFile);// streamReader.ReadToEnd();
//        //streamReader.Close();
//        string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(pathName);
//        text = Regex.Replace(text, "#NAME#", fileNameWithoutExtension);
//        text = Regex.Replace(text, "#NAMESPACE#", EntitiesEditor.nameSpace);
//        pathName = pathName.Replace(".cs", "Leaf.cs");
//        bool encoderShouldEmitUTF8Identifier = true;
//        bool throwOnInvalidBytes = false;
//        UTF8Encoding encoding = new UTF8Encoding(encoderShouldEmitUTF8Identifier, throwOnInvalidBytes);
//        bool append = false;
//        StreamWriter streamWriter = new StreamWriter(fullPath, append, encoding);
//        streamWriter.Write(text);
//        streamWriter.Close();
//        AssetDatabase.ImportAsset(pathName);
//        return AssetDatabase.LoadAssetAtPath(pathName, typeof(Object));
//    }
//}
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
        //StreamReader streamReader = new StreamReader(resourceFile);
        string text = File.ReadAllText(resourceFile);// streamReader.ReadToEnd();
        //streamReader.Close();
        string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(pathName);
        text = Regex.Replace(text, "#NAME#", fileNameWithoutExtension);
        text = Regex.Replace(text, "#NAMESPACE#", EntitiesEditor.nameSpace);
        pathName = pathName.Replace(".cs", "Pdr.cs");
        bool encoderShouldEmitUTF8Identifier = true;
        bool throwOnInvalidBytes = false;
        UTF8Encoding encoding = new UTF8Encoding(encoderShouldEmitUTF8Identifier, throwOnInvalidBytes);
        bool append = false;
        StreamWriter streamWriter = new StreamWriter(fullPath, append, encoding);
        streamWriter.Write(text);
        streamWriter.Close();
        AssetDatabase.ImportAsset(pathName);
        string path = Path.GetDirectoryName(pathName);
        //CreateOther(AssetDatabase.GUIDToAssetPath("0d7d6569c67d16e4d8577d86d78af2a4"), fileNameWithoutExtension, path);
        CreateOther(AssetDatabase.GUIDToAssetPath("1046749a25b181948b966fce10026735"), fileNameWithoutExtension, path);//waitleaf
        AssetDatabase.Refresh();
        return AssetDatabase.LoadAssetAtPath(pathName, typeof(Object));
    }
    static void CreateOther(string tmpPath,string cmpname,string floader)
    {
        string name = Path.GetFileNameWithoutExtension(tmpPath);
        name = Regex.Replace(name, "#NAME#", cmpname);
        string outPath = $"{floader}/{name}.cs";
        string text = File.ReadAllText(tmpPath);
        text = Regex.Replace(text, "#NAME#", cmpname);
        text = Regex.Replace(text, "#NAMESPACE#", EntitiesEditor.nameSpace);
        bool encoderShouldEmitUTF8Identifier = true;
        bool throwOnInvalidBytes = false;
        UTF8Encoding encoding = new UTF8Encoding(encoderShouldEmitUTF8Identifier, throwOnInvalidBytes);
        bool append = false;
        StreamWriter streamWriter = new StreamWriter(outPath, append, encoding);
        streamWriter.Write(text);
        streamWriter.Close();
    }
}