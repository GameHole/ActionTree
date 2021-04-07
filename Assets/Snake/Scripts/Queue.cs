using System;

namespace ActionTree
{
    public class MyQueue<T>
    {
        T[] array = new T[4];
        int head;
        int tail;
        int _count;
        public int Count => _count;
        public int Length => array.Length;
        public MyQueue()
        {
        }
        public MyQueue(int length)
        {
            array = new T[length];
        }
        public void Enqueue(T item)
        {
            MakeSure();
            _count++;
            array[tail++] = item;
            tail %= array.Length;
        }
        void MakeSure()
        {
            if (_count >= array.Length)
            {
                var newarr = new T[array.Length * 2];
                for (int i = 0; i < _count; i++)
                {
                    newarr[i] = this[i];
                }
                array = newarr;
                head = 0;
                tail = _count;
            }
        }
        public T Dequeue()
        {
            if (_count == 0)
                throw new ArgumentOutOfRangeException("queue is empty");
            _count--;
            var t = array[head++];
            head %= array.Length;
            return t;
        }
        public T Peek() => this[0];
        public T this[int index]
        {
            get
            {
                int len = array.Length;
                return array[(head + index) % len];
            }
        }
    }
}

