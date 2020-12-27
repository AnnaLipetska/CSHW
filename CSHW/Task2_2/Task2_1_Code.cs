using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_2
{
    public interface IMyLIst<T>
    {
        void Add(T a);
        T this[int index] { get; }
        int Count { get; }
        void Clear();
        bool Contains(T item);
    }

    public class MyList<T> : IMyLIst<T>
    {
        private T[] array = null;
        public MyList()
        {
            array = new T[0];
        }

        public int Count => array.Length;

        public void Add(T a)
        {
            var tempArr = new T[array.Length + 1];
            array.CopyTo(tempArr, 0);
            tempArr[array.Length] = a;
            array = tempArr;
        }

        public void Clear()
        {
            array = new T[0];
        }

        public bool Contains(T item)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i].Equals(item))
                {
                    return true;
                }
            }
            return false;
        }

        public T this[int index] => array[index];

        #region Foreach Members

        int position = -1;

        public void Reset()
        {
            position = -1;
        }

        public IEnumerator<T> GetEnumerator()
        {
            while (true)
            {
                if (position < array.Length - 1)
                {
                    position++;
                    yield return array[position];
                }
                else
                {
                    Reset();
                    yield break;
                }
            }
        }

        #endregion
    }
}
