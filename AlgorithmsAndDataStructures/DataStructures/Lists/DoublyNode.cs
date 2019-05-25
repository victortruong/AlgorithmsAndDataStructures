using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsAndDataStructures.DataStructures.Lists
{
    public class DoublyNode<T> where T: IComparable<T>
    {
        public DoublyNode<T> Next;
        public DoublyNode<T> Previous;
        public T Value;

        public DoublyNode(T value) 
        {
            this.Next = null;
            this.Previous = null;
            this.Value = value;
        }
    }
}
