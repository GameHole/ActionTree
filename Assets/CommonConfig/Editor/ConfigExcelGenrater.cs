using OfficeOpenXml;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using UnityEditor;
using UnityEngine;
namespace ActionTree
{
    [InitializeOnLoad]
    public class ConfigExcelGenrater
    {
        static string backupPath = "Assets/Editor/ConfigBackUp";
        static ConfigExcelGenrater()
        {
            ObjectFactory.componentWasAdded += onAddCmp;
        }
        private static void onAddCmp(Component obj)
        {
            if (obj is IConfigProxyPdr proxyPdr)
            {
                GenrateExcel(proxyPdr.GetElementType());
            }
        }
        public static void GenrateExcel(Type type)
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
            string path = Path.Combine(DirectroyWatcher.configExcel, $"{name}.xlsx");
            if (!File.Exists(path))
                File.Create(path).Dispose();
            var currinfo = new FileInfo(path);
            using (ExcelPackage package = new ExcelPackage(currinfo))
            {
                var fields = type.GetFields();
                ExcelWorksheet worksheet = package.Workbook.Worksheets["info"];
                if (worksheet == null || fields.Length > worksheet.Cells.Columns)
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
                        string backPath = $"{backupPath}/{name}-{DateTime.Now.ToString("yyyy-MM-dd-hh_mm_ss")}.xlsx";
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
        static void WriteDatas(ExcelWorksheet sor, ExcelWorksheet dest, string[] fieldStrs)
        {
            for (int i = 0; i < fieldStrs.Length; i++)
            {
                int keyId = indexOf(sor, fieldStrs[i]);
                if (keyId > 0)
                {
                    for (int r = 1; r < sor.Cells.Rows - 1; r++)
                    {
                        if (sor.Cells[r + 1, keyId].Value == null)
                            break;

                        dest.Cells[r + 1, i + 1].Value = sor.Cells[r + 1, keyId].Value;

                    }
                }
            }
        }
        static int indexOf(ExcelWorksheet sor, string key)
        {
            for (int i = 0; i < sor.Cells.Columns - 1; i++)
            {

                if (sor.Cells[2, i + 1].Value == null)
                    break;
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
        static int GetColumCount(ExcelWorksheet worksheet)
        {
            int i = 1;
            while (worksheet.Cells[2, i].Value != null)
            {
                i++;
            }
            return i - 1;
        }
        static bool isMatch(ExcelWorksheet worksheet, string[] fields)
        {
            int c = GetColumCount(worksheet);
            if (fields.Length < c)
                return false;
            for (int i = 0; i < fields.Length; i++)
            {
                if (fields[i] != worksheet.Cells[2, i+1].Value.ToString())
                {
                    return false;
                }
            }
            return true;
        }
    }
}
