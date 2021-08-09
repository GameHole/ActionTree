using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using System;
using System.Data;
using System.Text;
using System.Security.Cryptography;
using OfficeOpenXml;
using System.Reflection;

namespace ActionTree
{
    [InitializeOnLoad]
    public class DirectroyWatcher
    {
        static Dictionary<string, byte[]> buffer = new Dictionary<string, byte[]>();
        internal static string configExcel = "Assets/Editor/Configs";
        static string fallbackConfigTxtPath = "Assets/Resources/Configs";
        static DirectroyWatcher()
        {
            if (!Directory.Exists(configExcel))
                Directory.CreateDirectory(configExcel);
            EditorApplication.update += onUpdate;
        }
        
        [MenuItem("Excel/Load All")]
        static void LoadAll()
        {
            if (Directory.Exists(configExcel))
            {
                foreach (var item in Directory.GetFiles(configExcel))
                {
                    RepleaseConfig(item);
                }
            }
            AssetDatabase.Refresh();
        }
        static int count;
        //static System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
        static void onUpdate()
        {
            if (EditorApplication.isPlaying) return;
            count++;
            if (count >= 30)
            {
                //stopwatch.Restart();
                RepleaseChangedFile();
                //stopwatch.Stop();
                //Debug.Log(stopwatch.Elapsed);
                count = 0;
            }
        }
        static bool TryGetMd5(string path, out byte[] Md5)
        {
            try
            {
                using (var md5 = new MD5CryptoServiceProvider())
                {
                    byte[] fileData = File.ReadAllBytes(path);
                    Md5 = md5.ComputeHash(fileData);
                    return true;
                }
            }
            catch (IOException)
            {
                Md5 = default;
                //Debug.LogError(e.HResult);
                return false;
            }
        }
        static bool isFileChange(string filePath,out byte[] outMd5)
        {
            if (!TryGetMd5(filePath, out outMd5))
            {
                return false;
            }
            if (!buffer.TryGetValue(filePath, out var m))
            {
                m = outMd5;
                buffer.Add(filePath, m);
                return true;
            }
            return !isEqualMd5(m, outMd5);
        }
        static bool isEqualMd5(byte[]a ,byte[] b)
        {
            
            if (a.Length != b.Length) return false;
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] != b[i]) return false;
            }
            return true;
        }
        static string debug(byte[] a)
        {
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < a.Length; i++)
            {
                builder.Append(a[i].ToString("x2"));
            }
            return builder.ToString();
        }
        static void RepleaseChangedFile()
        {
            foreach (var item in Directory.GetFiles(configExcel))
            {
                if(isMapping(item) && isFileChange(item,out var md5))
                {
                    buffer[item] = md5;
                    Debug.Log("change");
                    RepleaseConfig(item);
                }
            }
        }
        static bool isMapping(string path)
        {
            var fileName = Path.GetFileName(path);
            return Path.GetExtension(fileName).Equals(".xlsx", StringComparison.CurrentCultureIgnoreCase) && !fileName.Contains("~$");
        }
        static void RepleaseConfig(string path)
        {
            var dataset = ExcelHelper.OpenExcel(path);
            if (dataset != null)
            {
                for (int i = 0; i < dataset.Tables.Count; i++)
                {
                    if (!DealTable(dataset.Tables[i]))
                    {
                        Debug.LogWarning($"Config file {path},it doesn't contain anything,so configuration files are not generated ");
                    }
                }
            }
            else
            {
                Debug.LogWarning("excel not found");
            }
        }
        static string FindResFloader()
        {
            var floader = AssetDatabase.FindAssets("ProjectFloader");
            if (floader.Length > 0)
            {
                string path = $"Assets/{File.ReadAllText(AssetDatabase.GUIDToAssetPath(floader[0]))}/Resources/Configs";
                if (!string.IsNullOrEmpty(path))
                    return path;
            }
            return fallbackConfigTxtPath;
        }
        static bool DealTable(DataTable table)
        {
            if (table.Rows.Count > 2)
            {
                var array = table.Rows[0].ItemArray;
                if (array.Length > 0)
                {
                    var className = table.Rows[0].ItemArray[0];
                    string resousePath = FindResFloader();
                    string targetPath = Path.Combine(resousePath, $"{className}.txt");
                    StringBuilder builder = new StringBuilder();
                    for (int i = 1; i < table.Rows.Count; i++)
                    {
                        var cols = table.Rows[i].ItemArray;
                        if (isEmptyLine(cols))
                        {
                            if (i == table.Rows.Count - 1)
                            {
                                builder[builder.Length - 1] = char.MinValue;
                                //Debug.Log(builder[builder.Length - 1]);
                            }
                            continue;
                        }
                        for (int j = 0; j < cols.Length; j++)
                        {
                            var item = cols[j];
                            //Debug.Log($" tp {targetPath} r {i} c {j} v {item}");
                            builder.Append(item);
                            if (j < cols.Length - 1)
                                builder.Append('/');
                        }
                        if (i < table.Rows.Count - 1)
                            builder.Append('\n');
                    }
                    //Debug.Log(builder.ToString(0,builder.Length));
                    if (!Directory.Exists(resousePath))
                        Directory.CreateDirectory(resousePath);
                    if (!File.Exists(targetPath))
                        File.Create(targetPath).Dispose();
                    File.WriteAllText(targetPath, builder.ToString());
                    return true;
                }
            }
            return false;
        }
        static bool isEmptyLine(object[] a)
        {
            for (int i = 0; i < a.Length; i++)
            {
                if (!string.IsNullOrEmpty(a[i].ToString()))
                    return false;
            }
            return true;
        }
    }
}

