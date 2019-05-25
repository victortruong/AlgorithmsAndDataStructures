using System;
namespace AlgorithmsAndDataStructures.DataStructures
{
    public class BinaryNode<T> : Node<T> where T : IComparable<T>
    {
        public BinaryNode<T> Left
        {
            get { return (BinaryNode<T>)Nodes[0]; }
            set { Nodes[0] = value; }
        }

        public BinaryNode<T> Right
        {
            get { return (BinaryNode<T>)Nodes[1]; }
            set { Nodes[1] = value; }
        }

        public BinaryNode(T value) : base(value)
        {
            Nodes = new BinaryNode<T>[] { null, null };
        }
    }
}
