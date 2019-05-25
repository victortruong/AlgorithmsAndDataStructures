using System;
using AlgorithmsAndDataStructures.DataStructures.Interfaces;

namespace AlgorithmsAndDataStructures.DataStructures.Trees
{
    public class BinaryTree<T> : ITree<T, BinaryNode<T>> where T : IComparable<T>
    {
        public BinaryNode<T> Root { get; set; }

        public BinaryNode<T> Delete(T value)
        {
            return Delete(Root, value);
        }

        private BinaryNode<T> Delete(BinaryNode<T> node, T value)
        {
            if (node == null)
            {
                return node;
            }

            if (node.Value.CompareTo(value) < 0)
            {
                node.Right = Delete(node.Right, value);
            }
            else if (node.Value.CompareTo(value) > 0)
            {
                node.Left = Delete(node.Left, value);
            }
            else
            {
                if (node.Left == null)
                {
                    return node.Right;
                }
                else if (node.Right == null)
                {
                    return node.Left;
                }

                node.Value = GetMinValue(node.Right);
                node.Right = Delete(node.Right, node.Value);
            }

            return node;
        }

        public T GetMaxValue()
        {
            if (Root == null)
            {
                throw new Exception("Tree is empty.");
            }

            return GetMaxValue(Root);
        }

        private T GetMaxValue(BinaryNode<T> node)
        {
            if (node.Right == null)
            {
                return node.Value;
            }

            return GetMaxValue(node.Right);
        }

        public T GetMinValue()
        {
            if (Root == null)
            {
                throw new Exception("Tree is empty.");
            }

            return GetMinValue(Root);
        }

        private T GetMinValue(BinaryNode<T> node)
        {
            if (node.Left == null)
            {
                return node.Value;
            }

            return GetMinValue(node.Left);
        }

        public BinaryNode<T> GetNode(T value)
        {
            return GetNode(Root, value);
        }

        private BinaryNode<T> GetNode(BinaryNode<T> node, T value)
        {
            if (node == null)
            {
                return null;
            }

            if (node.Value.CompareTo(value) == 0)
            {
                return node;
            }
            else if (node.Value.CompareTo(value) > 0)
            {
                return GetNode(node.Left, value);
            }
            else
            {
                return GetNode(node.Right, value);
            }
        }

        public BinaryNode<T> Insert(T value)
        {
            if (Root == null)
            {
                Root = Insert(Root, value);
                return Root;
            }

            return Insert(Root, value);
        }

        private BinaryNode<T> Insert(BinaryNode<T> node, T value)
        {
            if (node == null)
            {
                node = new BinaryNode<T>(value);
            }
            else if (node.Value.CompareTo(value) <= 0)
            {
                node.Right = Insert(node.Right, value);
            }
            else
            {
                node.Left = Insert(node.Left, value);
            }

            return node;
        }
    }
}
