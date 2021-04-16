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
        static string configExcel = "Assets/Editor/Configs";
        static string configTxtPath = "Assets/Resources/Configs";
        static string backupPath = "Assets/Editor/ConfigBackUp";
        static DirectroyWatcher()
        {
            if (!Directory.Exists(configExcel))
                Directory.CreateDirectory(configExcel);
            EditorApplication.update += onUpdate;
            ObjectFactory.componentWasAdded += onAddCmp;
        }
        private static void onAddCmp(Component obj)
        {
            if(obj is IConfigProxyPdr proxyPdr)
            {
                GenrateExcel(proxyPdr.GetElementType());
            }
        }
        static void GenrateExcel(Type type)
        {
            string name = null;
            var fileAtt = type.GetCustomAttribute<FileName>();
            if (fileAtt != null)
            {
                name = fileAtt.name;
            }
            else
            {
                name = type.FullName;
            }
            string path = Path.Combine(configExcel, $"{name}.xlsx");
            if (!File.Exists(path))
                File.Create(path).Dispose();
            var currinfo = new FileInfo(path);
            using (ExcelPackage package = new ExcelPackage(currinfo))
            {
                var fields = type.GetFields();
                ExcelWorksheet worksheet = package.Workbook.Worksheets["info"];
                if (worksheet == null|| fields.Length>worksheet.Cells.Columns)
                {
                    WriteTitle(package, type, fields);
                    package.Save();
                }
                else
                {
                    var strFields = DataDealer.ToStringArray(fields);
                    if (!isMatch(worksheet, strFields))
                    {
                        if (!Directory.Exists(backupPath))
                            Directory.CreateDirectory(backupPath);
                        string backPath = Path.Combine(backupPath, $"{name}.xlsx");
                        File.Copy(path, backPath);
                        File.Delete(path);
                        using (ExcelPackage newPack = new ExcelPackage(new FileInfo(path)))
                        {
                            WriteTitle(newPack, type, fields);
                            var newsheet = newPack.Workbook.Worksheets["info"];
                            WriteDatas(worksheet, newsheet, strFields);
                            newPack.Save();
                        }
                    }
                }
               
            }
            AssetDatabase.Refresh();
            Debug.Log($"File ({name}) Loaction = {path}");
        }
        static void WriteDatas(ExcelWorksheet sor,ExcelWorksheet dest,string[] fieldStrs)
        {
            for (int i = 0; i < fieldStrs.Length; i++)
            {
                int keyId = indexOf(sor, fieldStrs[i]);
                if (keyId > 0)
                {
                   
                    for (int r = 1; r < sor.Cells.Rows; r++)
                    {
                        if (sor.Cells[r + 1, keyId] == null)
                            break;

                        Debug.Log($"r {r + 1},c{i + 1} {dest} , {sor}");
                        dest.Cells[r + 1, i + 1].Value = sor.Cells[r + 1, keyId].Value;
                      
                    }
                }
            }
        }
        static int indexOf(ExcelWorksheet sor,string key)
        {
            for (int i = 0; i < sor.Cells.Columns - 1; i++)
            {
               
                if (sor.Cells[2, i + 1].Value == null)
                    break;

                Debug.Log($"c {sor.Cells.Columns}  i {i} {sor},{sor.Cells[2, i + 1].Value} { key}");
                if (sor.Cells[2, i + 1].Value.ToString() == key)
                {
                    return i + 1;
                }
            }
            return -1;
        }
        static void WriteTitle(ExcelPackage package, Type type, FieldInfo[] fields)
        {
            var worksheet = package.Workbook.Worksheets.Add("info");
            worksheet.Cells[1, 1].Value = type.FullName;
            for (int i = 0; i < fields.Length; i++)
            {
                string typeStr = DataDealer.ToString(fields[i].FieldType);
                worksheet.Cells[2, i + 1].Value = $"{typeStr} {fields[i].Name}";
            }
        }
        static bool isMatch(ExcelWorksheet worksheet,string[] fields)
        {
            if (fields.Length < worksheet.Cells.Columns)
                return false;
            for (int i = 0; i < fields.Length; i++)
            {
                if (fields[i] != worksheet.Cells[2, i].Value.ToString())
                {
                    return false;
                }
            }
            return true;
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
            count++;
            if (count >= 70)
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
                    DealTable(dataset.Tables[i]);
                }
            }
        }
        static void DealTable(DataTable table)
        {
            if (table.Rows.Count > 3)
            {
                var array = table.Rows[0].ItemArray;
                if (array.Length > 0)
                {
                    var className = table.Rows[0].ItemArray[0];
                    string targetPath = Path.Combine(configTxtPath, $"{className}.txt");
                    StringBuilder builder = new StringBuilder();
                    for (int i = 1; i < table.Rows.Count; i++)
                    {
                        var cols = table.Rows[i].ItemArray;
                        if (isEmptyLine(cols)) continue;
                        for (int j = 0; j < cols.Length; j++)
                        {
                            var item = cols[j].ToString();
                            builder.Append(item);
                            if (j < cols.Length - 1)
                                builder.Append('/');
                        }
                        if (i < table.Rows.Count - 1)
                            builder.Append('\n');
                    }
                    if (!Directory.Exists(configTxtPath))
                        Directory.CreateDirectory(configTxtPath);
                    if (!File.Exists(targetPath))
                        File.Create(targetPath).Dispose();
                    File.WriteAllText(targetPath, builder.ToString());
                }
            }
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

