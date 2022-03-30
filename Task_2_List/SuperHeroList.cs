using System;
using System.Collections;
using System.Collections.Generic;

namespace Task_2_List
{
    public class SuperHeroList<T> : IEnumerable<T>, IEnumerator<T>
    {
        internal class Node
        {
            public T data;
            public Node next = null;
            public Node(T item)
            {
                data = item;
            }
        }

        internal Node head;
        internal Node current;

        public object Current
        {
            get
            {
                return current.data;
            }
        }

        T IEnumerator<T>.Current
        {
            get
            {
                return current.data;
            }
        }

        public IEnumerator GetEnumerator()
        {
            return this;
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return this;
        }

        public bool MoveNext()
        {
            current = (current == null) ? head : current.next;
            return current != null;
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            current = null;
        
        }

        public void Add(T item)
        {
            Node node = new Node(item);
            if (head == null)
            {
                head = node;
            }
            else
            {
                Node curr = head;
                while (curr.next != null)
                {
                    curr = curr.next;
                }
                curr.next = node;
            }
        }

        /* Will remove the first occurence of the item, by its data */
        public void Remove(T item)
        {
            Node curr = head;
            Node prev = null;
            while (curr != null)
            {
                if (item.Equals(curr.data))
                {
                    if (prev == null)
                    {
                        head = curr.next; // No previous item - re-write head node
                    }
                    else
                    {
                        prev.next = curr.next;
                    }
                    break;
                }
                prev = curr;
                curr = curr.next;
            }
        }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= Length)
                {
                    throw new IndexOutOfRangeException();
                }
                Node curr = head;
                int currIndex = -1;
                while (curr != null)
                {
                    currIndex++;
                    if (currIndex == index)
                    {
                        return curr.data;
                    }
                    curr = curr.next;
                }
                return default(T);

            }
        }

        public int Length
        {
            get
            {
                int length = 0;
                Node curr = head;
                while (curr != null)
                {
                    length++;
                    curr = curr.next;
                }
                return length;
            }
        }
    }
}
