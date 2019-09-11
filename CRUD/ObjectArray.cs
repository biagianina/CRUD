using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CRUD
{
    public class List<T> : IList<T>
    {
        T[] array;

        public List()
        {
            this.array = new T[4];
        }

        public void Add(T element)
        {
            ResizeArray();
            array[Count] = element;
            Count++;
        }

        public int Count {get; private set;}

        public bool IsReadOnly => false;

        public T this[int index]
        {
            get => array[index];
            set => array[index] = value;
        }

        public void Insert(int index, T element)
        {
            ResizeArray();

            ShiftRight(index);

            array[index] = element;

            Count++;
        }

        public int IndexOf(T element)
        {
            for (int i = 0; i < Count; i++)
            {
                if (element.Equals(array[i]))
                {
                    return i;
                }
            }

            return -1;
        }

        public bool Contains(T element)
        {
            return IndexOf(element) != -1;
        }

        public void Clear()
        {
            Array.Resize(ref array, 0);
            Count = 0;
        }

        public void RemoveAt(int index)
        {
            ShiftLeft(index);
            Count--;
        }

        public bool Remove(T element)
        {
            if (IndexOf(element) == -1)
            {
                return false;
            }

            RemoveAt(IndexOf(element));
            return true;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return array[i];
            }
        }

        public void CopyTo(T[] targetArray, int arrayIndex)
        {
            for (int i = 0; i < Count; i++)
            {
                targetArray.SetValue(array[i], arrayIndex++);
            }
        }

        public bool IsSynchronized
        {
            get
            {
                return false;
            }
        }

        public object SyncRoot
        {
            get
            {
                return this;
            }
        }

        public bool IsFixedSize
        {
            get
            {
                return true;
            }
        }

        private void ResizeArray()
        {
            if (Count == array.Length)
            {
                Array.Resize(ref array, Count * 2);
            }
        }

        private void ShiftLeft(int index)
        {
            for (int i = index; i < Count - 1; i++)
            {
                array[i] = array[i + 1];
            }
        }

        private void ShiftRight(int index)
        {
            for (int i = array.Length - 1; i > index; i--)
            {
                array[i] = array[i - 1];
            }
        }
    }
}
