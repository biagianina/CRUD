using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CRUD
{
    public class ObjectArray : IEnumerable
    {
        object[] objectArray;

        public ObjectArray()
        {
            this.objectArray = new object[4];
        }

        public void Add(object element)
        {
            ResizeArray();
            objectArray[Count] = element;
            Count++;
        }

        public int Count {get; private set;}

        public object this[int index]
        {
            get => objectArray[index];
            set
            {
                objectArray[index] = value;
                Count++;
            }
        }

        public void Insert(int index, object element)
        {
            ResizeArray();

            ShiftRight(index);

            objectArray[index] = element;

            Count++;
        }

        public int IndexOf(object element)
        {
            for (int i = 0; i < Count; i++)
            {
                if (element.Equals(objectArray[i]))
                {
                    return i;
                }
            }

            return -1;
        }

        public bool Contains(object element)
        {
            return IndexOf(element) != -1;
        }

        public void Clear()
        {
            Array.Resize(ref objectArray, 0);
            Count = 0;
        }

        public void RemoveAt(int index)
        {
            ShiftLeft(index);
            Count--;
        }

        public void Remove(object element)
        {
            if (IndexOf(element) != -1)
            {
                RemoveAt(IndexOf(element));
            }
        }
        private void ResizeArray()
        {
            if (Count == objectArray.Length)
            {
                Array.Resize(ref objectArray, Count * 2);
            }
        }

        private void ShiftLeft(int index)
        {
            for (int i = index; i < Count - 1; i++)
            {
                objectArray[i] = objectArray[i + 1];
            }
        }

        private void ShiftRight(int index)
        {
            for (int i = objectArray.Length - 1; i > index; i--)
            {
                objectArray[i] = objectArray[i - 1];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator GetEnumerator()
        {
            return new ObjectEnumerator(objectArray);
        }
    }
}
