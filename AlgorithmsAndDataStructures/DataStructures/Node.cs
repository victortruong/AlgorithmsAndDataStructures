using System;
using System.Collections.Generic;

namespace AlgorithmsAndDataStructures.DataStructures
{
    public abstract class Node<T> where T : IComparable<T>
    {
        protected Node<T>[] Nodes { get; set; }
        public T Value { get; set; }

        public Node(T value)
        {
            this.Value = value;
        }
    }

}
