using UnityEngine;
using UnityEditor;
using System.IO;
using UnityEditor.ProjectWindowCallback;
using System.Text.RegularExpressions;
using System.Text;
[InitializeOnLoad]
public class EntitiesEditor : MonoBehaviour
{
    /*
        1.快捷键
        % - CTRL 在Windows / CMD在OSX
        # - Shift
        & - Alt
        LEFT/RIGHT/UP/DOWN-光标键
        F1…F12
        HOME,END,PGUP,PDDN 
     */
    [MenuItem("Assets/Create/ActionTree/Leaf With Provider", false, 0)]
    public static void CreateTreeProviderScript()
    {
        var path = AssetDatabase.GUIDToAssetPath("65b4689b4dc1a5b4da96cf422ba631fb");
        ProjectWindowUtil.StartNameEditingIfProjectWindowExists(0,
        ScriptableObject.CreateInstance<MyDoCreateLeafScriptAsset>(),
        GetSelectedPathOrFallback() + "/NewLeafPdr.cs", null, path);
    }
    [MenuItem("Assets/Create/ActionTree/Component With Provider", false, 0)]
    public static void CreateCmpProviderScript()
    {
        var path = AssetDatabase.GUIDToAssetPath("cd26b352f77532b4985a5b671083808f");
        ProjectWindowUtil.StartNameEditingIfProjectWindowExists(0,
        ScriptableObject.CreateInstance<MyDoCreateAdaptorScriptAsset>(),
        GetSelectedPathOrFallback() + "/NewComponentPdr.cs", null, path);
    }
    [MenuItem("Assets/Create/ActionTree/Component", false, 0)]
    public static void CreateControlCmpScript()
    {
        var path = AssetDatabase.GUIDToAssetPath("95d1de00bfa5f904ea49a82e9ede6a44");
        ProjectWindowUtil.StartNameEditingIfProjectWindowExists(0,
        ScriptableObject.CreateInstance<MyDoCreateScriptAsset>(),
        GetSelectedPathOrFallback() + "/NewComponent.cs", null, path);
    }
    [MenuItem("Assets/Create/ActionTree/Leaf", false, 0)]
    public static void CreateLeafScript()
    {
        var path = AssetDatabase.GUIDToAssetPath("4c15340607f603348890f5be789307df");
        ProjectWindowUtil.StartNameEditingIfProjectWindowExists(0,
        ScriptableObject.CreateInstance<MyDoCreateScriptAsset>(),
        GetSelectedPathOrFallback() + "/NewLeaf.cs", null, path);
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
    static EntitiesEditor()
    {
        string[] guids = AssetDatabase.FindAssets("namespace");
        if (guids.Length > 0)
        {
            nameSpace = File.ReadAllText(AssetDatabase.GUIDToAssetPath(guids[0]));
        }
        SetOrder("8ac578ffc71250d4b96754cf53ef899f", -2000);
        NoWarn();
    }
    static void SetOrder(string guid, int order)
    {
        var mono = AssetDatabase.LoadAssetAtPath<MonoScript>(AssetDatabase.GUIDToAssetPath(guid));
        if (MonoImporter.GetExecutionOrder(mono) != order)
            MonoImporter.SetExecutionOrder(mono, order);
    }
    public readonly static string nameSpace = "Default";
    static void NoWarn()
    {
        string path = "Assets/csc.rsp";
        if (!File.Exists(path))
        {
            File.WriteAllText(path, "-nowarn:0649");
            AssetDatabase.Refresh();
        }
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
class MyDoCreateLeafScriptAsset : EndNameEditAction
{
    public override void Action(int instanceId, string pathName, string resourceFile)
    {
        Object o = CreateScriptAssetFromTemplate(pathName, resourceFile);
        ProjectWindowUtil.ShowCreatedAsset(o);
    }

    internal static Object CreateScriptAssetFromTemplate(string pathName, string resourceFile)
    {

        string fullPath = Path.GetFullPath(pathName);
        fullPath = fullPath.Replace(".cs", "Leaf.cs");
        //StreamReader streamReader = new StreamReader(resourceFile);
        string text = File.ReadAllText(resourceFile);// streamReader.ReadToEnd();
        //streamReader.Close();
        string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(pathName);
        text = Regex.Replace(text, "#NAME#", fileNameWithoutExtension);
        text = Regex.Replace(text, "#NAMESPACE#", EntitiesEditor.nameSpace);
        pathName = pathName.Replace(".cs", "Leaf.cs");
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
        return AssetDatabase.LoadAssetAtPath(pathName, typeof(Object));
    }
}