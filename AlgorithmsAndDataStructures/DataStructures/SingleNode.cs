using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsAndDataStructures.DataStructures
{
    public class SingleNode<T> : Node<T> where T : IComparable<T>
    {
        public SingleNode<T> Next
        {
            get { return (SingleNode<T>)Nodes[0]; }
            set { Nodes[0] = value; }
        }

        public SingleNode(T value) : base(value)
        {
            Nodes = new SingleNode<T>[1];
        }
    }
}
