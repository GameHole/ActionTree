using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace ActionTree
{
    public abstract class DataDealer
    {
        protected static readonly DataDealer[] dealers;
        static DataDealer()
        {
            dealers = new DataDealer[6];
            var intDealer = new IntDealer();
            var floatDealer = new FloatDealer();
            var stringDealer = new StringDealer();
            dealers[0] = intDealer;
            dealers[1] = floatDealer;
            dealers[2] = stringDealer;
            dealers[3] = new ArrayDealer<IntDealer>(intDealer);
            dealers[4] = new ArrayDealer<FloatDealer>(floatDealer);
            dealers[5] = new ArrayDealer<StringDealer>(stringDealer);
        }
        public static bool isMatch(string fieldTypeStr,Type fieldType,out DataDealer dealer)
        {
            dealer = default;
            for (int i = 0; i < dealers.Length; i++)
            {
                if (dealers[i].isSupport(fieldTypeStr))
                {
                    bool contain = dealers[i].isContain(fieldType);
                    if (contain)
                        dealer = dealers[i];
                    return contain;
                }
            }
            return false;
        }
        public static string ToString(Type type)
        {
            for (int i = 0; i < dealers.Length; i++)
            {
                if (dealers[i].isContain(type))
                {
                    return dealers[i].ToFieldTypeStr(type);
                }
            }
            throw new ArgumentException($"class {type.DeclaringType}`s field type {type} is not support");
        }
        public static string[] ToStringArray(FieldInfo[] info)
        {
            string[] rts = new string[info.Length];
            for (int i = 0; i < info.Length; i++)
            {
                rts[i] =$"{ToString(info[i].FieldType)} {info[i].Name}";
            }
            return rts;
        }
        public abstract bool isSupport(string fieldTypeStr);
        public abstract bool isContain(Type fieldType);
        public abstract object GetValue(string str, Type fieldType);

        public abstract string ToFieldTypeStr(Type fieldType);
    }
    class IntDealer : DataDealer
    {
        static readonly Type[] intTypes = new Type[]
        {
             typeof(int),typeof(long)
        };
        static readonly Func<string, object>[] intTaker = new Func<string, object>[]
        {
             (str)=>{if(int.TryParse(str,out var v))return v;else return 0; },
             (str)=>{if(long.TryParse(str,out var v))return v;else return 0; },
        };
        public override string ToFieldTypeStr(Type fieldType) => "int";

        public override object GetValue(string str, Type fieldType)
        {
            for (int i = 0; i < intTypes.Length; i++)
            {
                if (fieldType == intTypes[i])
                {
                    return intTaker[i].Invoke(str);
                }
            }
            return 0;
        }

        public override bool isContain(Type fieldType)
        {
            for (int i = 0; i < intTypes.Length; i++)
            {
                if (fieldType == intTypes[i])
                    return true;
            }
            return false;
        }

        public override bool isSupport(string fieldTypeStr)
        {
            return fieldTypeStr == "int";
        }
    }
    class FloatDealer : DataDealer
    {
        public override string ToFieldTypeStr(Type fieldType) => "float";
        static readonly Type[] floatTypes = new Type[]
        {
            typeof(float),typeof(double)
        };
        static readonly Func<string, object>[] intTaker = new Func<string, object>[]
        {
            (str)=>{if(float.TryParse(str,out var v))return v;else return 0; },
            (str)=>{if(double.TryParse(str,out var v))return v;else return 0; },
        };
        public override object GetValue(string str, Type fieldType)
        {
            if (!string.IsNullOrEmpty(str))
            {
                for (int i = 0; i < floatTypes.Length; i++)
                {
                    if (fieldType == floatTypes[i])
                    {
                        return intTaker[i].Invoke(str);
                    }
                }
            }
            return 0;
        }

        public override bool isContain(Type fieldType)
        {
            for (int i = 0; i < floatTypes.Length; i++)
            {
                if (fieldType == floatTypes[i])
                    return true;
            }
            return false;
        }

        public override bool isSupport(string fieldTypeStr)
        {
            return "float" == fieldTypeStr;
        }
    }
    class StringDealer : DataDealer
    {
        public override string ToFieldTypeStr(Type fieldType) => "string";

        public override object GetValue(string str, Type fieldType)
        {
            return str.Trim();
        }

        public override bool isContain(Type fieldType)
        {
            return fieldType == typeof(string);
        }

        public override bool isSupport(string fieldTypeStr) => fieldTypeStr == "string";
    }
    class ArrayDealer<T> : DataDealer where T:DataDealer
    {
        T elementDealer;
        public ArrayDealer(T elementDealer)
        {
            this.elementDealer = elementDealer;
        }
        public override string ToFieldTypeStr(Type fieldType) => $"Array<{elementDealer.ToFieldTypeStr(fieldType.GetElementType())}>";

        public override object GetValue(string str, Type fieldType)
        {
            var values = str.Split(',','，');
            var eleType = fieldType.GetElementType();
            var array = Array.CreateInstance(eleType, values.Length);
            for (int i = 0; i < values.Length; i++)
            {
                array.SetValue(elementDealer.GetValue(values[i], eleType), i);
            }
            return array;
        }

        public override bool isContain(Type fieldType)
        {
            if (fieldType.IsArray && fieldType.HasElementType)
            {
                return elementDealer.isContain(fieldType.GetElementType());
            }
            return false;
        }

        public override bool isSupport(string fieldTypeStr)
        {
            if (fieldTypeStr.StartsWith("Array"))
            {
                int start = fieldTypeStr.IndexOf("<") + 1;
                int end = fieldTypeStr.LastIndexOf(">");
                string genType = fieldTypeStr.Substring(start, end - start);
                return elementDealer.isSupport(genType);
            }
            return false;
        }
    }
}
