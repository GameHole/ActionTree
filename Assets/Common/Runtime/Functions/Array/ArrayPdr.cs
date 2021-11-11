using System.Collections.Generic;
using ActionTree;
using UnityEngine;
using System.Collections;
namespace ActionTree
{
    public class AArray: IComponent
    {
        public virtual int Length { get; }
    }
    [System.Serializable]
	public class Array<T> : AArray, IEnumerable<T>
	{
        public List<T> value = new List<T>();
        public void Set(T[] array)
        {
            value.AddRange(array);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return value.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public T this[int idx]
        {
            get
            {
                return value[idx];
            }
            set
            {
                this.value[idx] = value;
            }
        }
        public override int Length
        {
            get
            {
                return value.Count;
            }
        }
        public void Add(T item)
        {
            value.Add(item);
        }
	}
	//public class ArrayPdr<T>: CmpProvider<Array<T>> { }
}
