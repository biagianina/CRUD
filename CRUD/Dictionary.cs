using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CRUD
{
    public class Dictionary<TKey, TValue> : IDictionary<TKey, TValue>
    {
        readonly Element<TKey, TValue>[] elements;
        readonly int[] buckets;
        readonly int size;
        int freeIndex = -1;
        
        public Dictionary(int size)
        {
            this.elements = new Element<TKey, TValue>[size];
            this.buckets = new int[size];
            Array.Fill(buckets, -1);
            this.size = size;
        }
        public TValue this[TKey key]
        {
            get
            {
                if (TryGetIndexOfKey(key, out int index))
                {
                    return elements[index].Value;
                }
                else
                {
                    return default;
                }
            }
            set
            {
                if (TryGetIndexOfKey(key, out int index))
                {
                    elements[index].Value = value;
                }
                else
                {
                    Add(key, value);
                }
            }
        }

        public ICollection<TKey> Keys
        {
            get
            {
                TKey[] keys = new TKey[Count];
                int keyCount = 0;
                for (int i = 0; i < size; i++)
                {
                    if (elements[i] != null &&  elements[i].Value != default && elements[i].Key != default)
                    {
                        keys[keyCount] = elements[i].Key;
                        keyCount++;
                    }
                    else
                    {
                        continue;
                    }
                }

                return keys;
            }
        }
        public ICollection<TValue> Values
        {
            get
            {
                TValue[] values = new TValue[Count];
                int valueCount = 0;
                for (int i = 0; i < size; i++)
                {
                    if (elements[i] != null && elements[i].Value != default && elements[i].Key != default)
                    {
                        values[valueCount] = elements[i].Value;
                        valueCount++;
                    }
                    else
                    {
                        continue;
                    }
                }

                return values;
            }
        }

        public int Count { get; set; }

        public bool IsReadOnly { get; }

        public void Add(TKey key, TValue value)
        {
            CheckKeyDuplicate(key);
            int bucketNumber = GetBucket(key);
            int elementIndex = CheckFreePosition();
            if (buckets[bucketNumber] == -1)
            {
                if (elementIndex != Count)
                {
                    freeIndex = elements[elementIndex].Next;
                }
                elements[elementIndex] = new Element<TKey, TValue>(key, value);
                buckets[bucketNumber] = elementIndex;
                Count++;
            }
            else
            {
                if (elementIndex != Count)
                {
                    freeIndex = elements[elementIndex].Next;
                }
                elements[elementIndex] = new Element<TKey, TValue>(key, value, buckets[bucketNumber]);
                buckets[bucketNumber] = elementIndex;
                Count++;
            }
        }

        

        public void Add(KeyValuePair<TKey, TValue> item)
        {
            Add(item.Key, item.Value);
        }

        public void Clear()
        {
            Count = 0;
            for(int i = 0; i < size; i++)
            {
                elements[i] = default;
                buckets[i] = -1;
            }
        }

        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            if (ContainsKey(item.Key))
            {
                return this[item.Key].Equals(item.Value);
            }

            return false;
        }

        public bool ContainsKey(TKey key)
        {
            int bucketNumber = GetBucket(key);
            for (int i = buckets[bucketNumber]; i > -1; i = elements[i].Next)
            {
                
                if (elements[i].Key.Equals(key))
                {
                    return true;
                }
            }

            return false;
        }

        

        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            if (Count > array.Length)
            {
                throw new ArgumentException("Array is smaller than dictionary");
            }

            foreach (var current in elements)
            {
                array.SetValue(current, arrayIndex++);
            }
        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            foreach (var kvp in elements)
            {
                if (kvp != null && kvp.Key != default && kvp.Value != default)
                {
                    yield return new KeyValuePair<TKey, TValue>(kvp.Key, kvp.Value);
                }
            }
        }

        public bool Remove(TKey key)
        {
            CheckKey(key);

            int bucketNumber = GetBucket(key);
            int elementIndex = buckets[bucketNumber];
            var first = elements[elementIndex];

            if (first.Key.Equals(key))
            {
                buckets[bucketNumber] = first.Next;
                Delete(first);
                freeIndex = elementIndex;
                Count--;
                return true;
            }
            else
            {
                var current = elements[first.Next];
                for (int i = first.Next; i > -1; i = current.Next)
                {
                    int previous = i;
                    if (elements[i].Key.Equals(key))
                    {
                        if (i != previous)
                        {
                            elements[previous].Next = elements[i].Next;
                        }
                        else
                        {
                            first.Next = elements[i].Next;
                        }
                        Delete(elements[i]);
                        freeIndex = i;
                        Count--;
                        return true;
                    }
                }
            }

            return false;

        }

        

        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            return Remove(item.Key);
        }
       
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public bool TryGetValue(TKey key, out TValue value)
        {
            if (TryGetIndexOfKey(key, out int index))
            {
                value = elements[index].Value;
            }
            else
            {
                value = default;
            }

            return value != default;
        }


        private bool TryGetIndexOfKey(TKey key, out int index)
        {
            for (index = 0; index < Count; index++)
            {
                if (elements[index].Key.Equals(key)) return true;
            }

            return false;
        }

        private int GetBucket(TKey key)
        {
            int bucketNumber = Math.Abs(key.GetHashCode());
            if (bucketNumber > size - 1)
            {
                bucketNumber %= size;
            }

            return bucketNumber;
        }

        private void Delete(Element<TKey, TValue> element)
        {
            element.Key = default;
            element.Value = default;
            element.Next = freeIndex;
        }

        private void CheckKeyDuplicate(TKey key)
        {
            if (ContainsKey(key))
            {
                throw new ArgumentException("Key already exists");
            }
        }

        private void CheckKey(TKey key)
        {
            if (!ContainsKey(key))
            {
                throw new ArgumentException("Key not found");
            }
        }

        private int CheckFreePosition()
        {
            if (freeIndex != -1)
            {
                return freeIndex;
            }

            if (Count == size)
            {
                throw new InvalidOperationException("Dictionary is full!");
            }

            return Count;
        }
    }
}
