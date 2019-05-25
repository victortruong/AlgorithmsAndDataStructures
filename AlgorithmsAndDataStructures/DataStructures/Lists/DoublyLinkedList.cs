using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsAndDataStructures.DataStructures.Lists
{
    public class DoublyLinkedList<T> : ILinkList<T> where T: IComparable<T>
    {
        DoublyNode<T> Head;

        public int Count
        {
            get; private set;
        }

        public void AddFirst(T value)
        {
            DoublyNode<T> temp = new DoublyNode<T>(value);
            temp.Next = Head;
            if (Head != null)
            {
                Head.Previous = temp;
            }
            Head = temp;
            Count++;
        }

        public void AddLast(T value)
        {
            if (Count <= 1)
            {
                AddFirst(value);
            }
            else
            {
                DoublyNode<T> temp = new DoublyNode<T>(value);
                DoublyNode<T> lastNode = GetLastNode();
                lastNode.Next = temp;
                temp.Previous = lastNode;
                Count++;
            }            
        }

        private DoublyNode<T> GetLastNode()
        {
            DoublyNode<T> temp = Head;
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
            DoublyNode<T> temp = Head;
            while(temp != null)
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
                DoublyNode<T> lastNode = GetLastNode();
                return lastNode.Value;
            }
        }

        public void Remove(T value)
        {
            DoublyNode<T> temp = Head;
            while (temp != null)
            {
                if (temp.Value.Equals(value))
                {
                    temp.Previous.Next = temp.Next;
                    temp.Next.Previous = temp.Previous;
                    Count--;
                    break;
                }
            }
        }

        public void RemoveFirst()
        {
            if (Head != null)
            {
                Head = Head.Next;
                if (Head!= null)
                {
                    Head.Previous = null;
                }
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
                DoublyNode<T> lastNode = GetLastNode();
                lastNode.Previous.Next = null;
                lastNode.Previous = null;
                Count--;
            }
        }
    }
}
