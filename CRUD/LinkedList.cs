using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CRUD
{
    public class LinkedList<T> : ICollection<T>
    {
        public LinkedListNode<T> Head;

        public LinkedList()
        {
            Head = new LinkedListNode<T>(default);
            Head.Previous = Head;
            Head.Next = Head;
            Head.NodeList = this;
        }
        public int Count { get; private set; }

        public bool IsReadOnly { get; }

        public LinkedListNode<T> First
        {
            get
            {
                if (Count == 0)
                {
                    return null;
                }

                return Head.Next;
            }
        }

        public LinkedListNode<T> Last
        {
            get
            {
                if (Count == 0)
                {
                    return null;
                }

                return Head.Previous;
            }
        }


        public void Add(T item)
        {
            AddLast(item);
        }

        public void AddAfter(LinkedListNode<T> node, LinkedListNode<T> newNode)
        {
            newNode.NodeList = this;
            newNode.Previous = node;
            newNode.Next = node.Next;
            node.Next.Previous = newNode;
            node.Next = newNode;
            Count++;
        }

        public void AddAfter(LinkedListNode<T> node, T item)
        {
            AddAfter(node, new LinkedListNode<T>(item));
        }

        public void AddBefore(LinkedListNode<T> node, LinkedListNode<T> newNode)
        {
            AddAfter(node.Previous, newNode);
        }

        public void AddBefore(LinkedListNode<T> node, T item)
        {
            AddBefore(node, new LinkedListNode<T>(item));
        }

        public void AddFirst(LinkedListNode<T> newNode)
        {
            AddAfter(Head, newNode);
        }

        public void AddFirst(T item)
        {
            AddFirst(new LinkedListNode<T>(item));
        }

        public void AddLast(LinkedListNode<T> newNode)
        {
            AddBefore(Head, newNode);
        }

        public void AddLast(T item)
        {
            AddLast(new LinkedListNode<T>(item));
        }
        public void Clear()
        {
            Count = 0;
            Head.Next = Head;
            Head.Previous = Head;
        }

        public bool Contains(T item)
        {
            return Find(item) != null;
        }

        public LinkedListNode<T> Find(T item)
        {
            for (var current = Head.Next; current != Head; current = current.Next)
            {
                if (current.Value.Equals(item))
                {
                    return current;
                }
            }

            return null;
        }

        public LinkedListNode<T> FindLast(T item)
        {
            for (var current = Head.Previous; current != Head; current = current.Previous)
            {
                if (current.Value.Equals(item))
                {
                    return current;
                }
            }

            return null;
        }
        public void CopyTo(T[] array, int arrayIndex)
        {
            if (Count > array.Length)
            {
                throw new ArgumentException("Array is smaller than list"); 
            }

            foreach(var current in this)
            {
                array.SetValue(current, arrayIndex++);
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (var current = Head.Next; current != Head; current = current.Next)
            {
                yield return current.Value;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public bool Remove(T item)
        {
            LinkedListNode<T> node = Find(item);
            if (node != null)
            {
                Remove(node);

                return true;
            }

            return false;
        }

        public void Remove(LinkedListNode<T> node)
        {
            if (node == Head)
            {
                throw new NotSupportedException();
            }

            node.Previous.Next = node.Next;
            node.Next.Previous = node.Previous;
            node.NodeList = null;
            Count--;

        }

        public void RemoveFirst()
        {
            Remove(Head.Next);
        }

        public void RemoveLast()
        {
            Remove(Head.Previous);
        }

        public void Display()
        {
            foreach (var member in this)
            {
                Console.Write(member + " ");
            }
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}

