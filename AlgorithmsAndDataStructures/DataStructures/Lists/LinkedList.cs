using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsAndDataStructures.DataStructures.Lists
{
    public class LinkedList<T> : ILinkList<T> where T: IComparable<T>
    {
        SingleNode<T> Head;

        public int Count
        {
            get; private set;
        }

        public void AddFirst(T value)
        {
            SingleNode<T> temp = new SingleNode<T>(value);
            temp.Next = Head;
            Head = temp;
            Count++;
        }

        public void AddLast(T value)
        {
            if (Count == 0)
            {
                AddFirst(value);
            }
            else
            {
                SingleNode<T> temp = new SingleNode<T>(value);
                SingleNode<T> lastNode = GetLastNode();
                lastNode.Next = temp;
                Count++;
            }
        }

        private SingleNode<T> GetLastNode()
        {
            SingleNode<T> temp = Head;
            while (temp.Next != null)
            {
                temp = temp.Next;
            }

            return temp;
        }

        public void Clear()
        {
            Head = null;
            Count = 0;

        }

        public bool Contains(T value)
        {
            SingleNode<T> temp = Head;
            while (temp != null)
            {
                if (temp.Value.Equals(value))
                {
                    return true;
                }
                temp = temp.Next;
            }
            return false;
        }

        public T GetFirst()
        {
            if (Head != null)
            {
                return Head.Value;
            }

            throw new Exception("Linked list is empty");
        }

        public T GetLast()
        {
            if (Count <= 1)
            {
                return GetFirst();
            }
            else
            {
                SingleNode<T> lastNode = GetLastNode();
                return lastNode.Value;
            }
        }

        public void Remove(T value)
        {
            SingleNode<T> previous = null;
            SingleNode<T> current = Head;
            while (current != null)
            {
                if (current.Value.Equals(value))
                {
                    if (previous != null)
                    {
                        previous.Next = current.Next;
                    }
                    Count--;
                    break;
                }
                previous = current;
                current = current.Next;
            }
        }

        public void RemoveFirst()
        {
            if (Head != null)
            {
                Head = Head.Next;
                Count--;
            }
        }

        public void RemoveLast()
        {
            if (Count <= 1)
            {
                RemoveFirst();
            }
            else
            {
                SingleNode<T> previous = null;
                SingleNode<T> current = Head;

                while (current.Next != null)
                {
                    previous = current;
                    current = current.Next;
                }

                previous.Next = null;
                Count--;
            }
        }
    }
}

