using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
namespace ActionTree
{
    [Serializable]
    public unsafe class DataSaver:IDisposable,IComponent
    {
        public string floaderName;
        public string fileName;
        
        FileStream stream;
        class DataElement
        {
            int _startIndex;
            int _valueIndex;
            int keyLen;
            int vLen;
            string _key;
            public byte[] _value;
            public int total;
            public DataElement(string key,byte[] item,int index)
            {
                keyLen = key.Length * sizeof(char);
                //Alin(ref keyLen);
                vLen = item.Length;
                //Alin(ref vLen);
                total = keyLen + vLen + sizeof(int) * 2;
                _value = item;
                _key = key;
                _startIndex = index;
                _valueIndex = _startIndex + keyLen + sizeof(int);
            }
            static void Alin(ref int v,int k = 4)
            {
                v += 4 - v % 4;
            }
            public void CopyTo(byte* arr)
            {
                *(int*)(arr + _startIndex) = keyLen;
                int idx = _startIndex + sizeof(int);
                for (int i = 0; i < _key.Length; i++, idx += sizeof(char))
                {
                    *(char*)(arr + idx) = _key[i];
                }
                *(int*)(arr + idx) = vLen;
                idx += sizeof(int);
                for (int i = 0; i < _value.Length; i++)
                {
                    (arr + idx)[i] = _value[i];
                }
            }
        }
        Dictionary<string, DataElement> keyToIndex = new Dictionary<string, DataElement>();
        byte[] datas;
        int index;
        public void Set<T>(string key, T value,bool saveImd=false) where T : unmanaged
        {
            if (!keyToIndex.TryGetValue(key, out var element))
            {
                element = new DataElement(key, new byte[sizeof(T)], index);
                keyToIndex.Add(key, element);
                MakeSureCap(element.total);
                index += element.total;
            }
            //Debug.Log(datas);
            fixed (byte* vptr = element._value)
            {
                *(T*)vptr = value;
            }
            fixed (byte* ptr = datas)
            {
                element.CopyTo(ptr);
            }
            if (saveImd)
            {
                Save();
            }
        }
        public void Save()
        {
            stream.Position = 0;
            stream.Write(datas,0, index);
        }
        public void Init()
        {
            if (!Directory.Exists(floaderName))
                Directory.CreateDirectory(floaderName);
            string path = $"{floaderName}/{fileName}.kv";
            if (File.Exists(path))
            {
                datas = File.ReadAllBytes(path);
                index = datas.Length;
                ReadFromDatas();
                stream = File.Open(path, FileMode.Open, FileAccess.ReadWrite);
            }
            else
            {
                stream = File.Create(path);
            }
        }
        void ReadFromDatas()
        {
            fixed (byte* ptr = datas)
            {
                for (int i = 0; i < datas.Length;)
                {
                    int index = i;
                    int keyLen = *(int*)(ptr + i);
                    i += sizeof(int);
                    string key = new string((char*)(ptr + i), 0, keyLen / sizeof(char));
                    i += keyLen;
                    int vLen = *(int*)(ptr + i);
                    i += sizeof(int);
                    byte[] arr = new byte[vLen];
                    for (int v = 0; v < arr.Length; v++, i++)
                    {
                        arr[v] = ptr[i];
                    }
                    DataElement data = new DataElement(key, arr, index);
                    keyToIndex.Add(key, data);
                }
            }
           
        }
        public T Get<T>(string key, T defaultValue = default) where T : unmanaged
        {
            if (!keyToIndex.TryGetValue(key, out var item))
            {
                return defaultValue;
            }
            fixed (byte* ptr = item._value)
                return *(T*)ptr;
        }
        void MakeSureCap(int need)
        {
            
            if (datas == null)
            {
                int n = (need / 2) + 1;
                datas = new byte[n * 2];
            }
            else
            {
                int n = index + need;
                if (n > datas.Length)
                {
                    var newArr = new byte[2 * n];
                    Array.Copy(datas, newArr, datas.Length);
                    datas = newArr;
                }
            }
        }

        public void Dispose()
        {
            stream?.Dispose();
            keyToIndex.Clear();
            index = 0;
            datas = null;
        }
    }
    public class DataSaverPdr : CmpProvider<DataSaver>
    {
        public override IComponent GetValue()
        {
            value.floaderName = $"{Application.persistentDataPath}/{value.floaderName}";
            return value;
        }
        private void OnDestroy()
        {
            value?.Dispose();
        }
    }
}

