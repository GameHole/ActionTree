using System;
using System.Collections;
using System.Collections.Generic;
using ActionTree;
using UnityEngine;
namespace ActionTree
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class FileName : Attribute
    {
        public string name;
        public FileName(string name)
        {
            this.name = name;
        }
    }
	public abstract class AConfig : IComponent
    {
        internal string configTxt;
        internal Type classType;
        internal abstract void Set(int idx, IConfigValue value);
        public abstract int Length
        {
            get;
            internal set;
        }
	}
    public class Config<T> : AConfig,IEnumerable<T> where T:class, IConfigValue
    {
        T[] values;
        public T this[int index]
        {
            get
            {
                if (values == null)
                    throw new ArgumentException($"Config {GetType()} not init");
                if (index >= Length)
                    index = Length - 1;
                else if (index < 0)
                    index = 0;
                return values[index];
            }
            internal set => values[index] = value;
        }
        public override int Length
        {
            get => values == null ? 0 : values.Length;
            internal set => values = new T[value];
        }

        public IEnumerator<T> GetEnumerator()
        {
            return GetEnumerator();
        }

        internal override void Set(int idx, IConfigValue value)
        {
            this[idx] = value as T;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return values.GetEnumerator();
        }
    }
    public interface IConfigProxyPdr
    {
        Type GetElementType();
    }
    public abstract class ConfigProxyPdr<T>: CmpProvider<Config<T>>, IConfigProxyPdr where T :class,IConfigValue, new()
    {
        public Type GetElementType()
        {
            return typeof(T);
        }

        public override IComponent GetValue()
        {
            var loaded = Resources.Load<TextAsset>($"Configs/{typeof(T).FullName}");
            if (loaded != null)
            {
                //AConfigArray.Add(typeof(T));
                value.configTxt = loaded.text;
                value.classType = typeof(T);
            }
            else
            {
                throw new ArgumentException($"Config File {typeof(T).FullName}.txt not found in Resources floader,please makesure config genrated");
            }
            return base.GetValue();
        }
    }
}
