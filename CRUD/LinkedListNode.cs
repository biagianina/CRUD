namespace CRUD
{
    public class LinkedListNode<T>
    {
        public LinkedList<T> NodeList { get; set; }
        public T Value { get; set; }
        public LinkedListNode(T item)
        {
            this.Value = item;
        }

        public LinkedListNode<T> Next { get; set; }
        public LinkedListNode<T> Previous { get; set; }
      
            }
}
