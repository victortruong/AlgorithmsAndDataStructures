using System;
namespace AlgorithmsAndDataStructures.DataStructures
{
    public class AVLNode<T> : BinaryNode<T> where T : IComparable<T>
    {
        public int Height { get; set; }

        public AVLNode(T value) : base(value)
        {
            Height = 1;
        }


        // TODO I'm not sure if this is good. Will think about this.
        public new AVLNode<T> Left
        {
            get { return (AVLNode<T>)Left; }
            set { Left = value; }
        }

        public new AVLNode<T> Right
        {
            get { return (AVLNode<T>)Right; }
            set { Right = value; }
        }

    }
}
