using System;
using AlgorithmsAndDataStructures.DataStructures.Interfaces;

namespace AlgorithmsAndDataStructures.DataStructures.Trees
{
    // TODO Untested
    public class AVLTree<T> : ITree<T, AVLNode<T>> where T : IComparable<T>
    {
        public AVLNode<T> Root { get; set; }

        public AVLNode<T> Delete(T value)
        {
            return Delete(Root, value);
        }

        public AVLNode<T> Delete(AVLNode<T> node, T value)
        {
            if (node == null)
            {
                return node;
            }
            else if (node.Value.CompareTo(value) < 0)
            {
                return Delete(node.Right, value);
            }
            else if (node.Value.CompareTo(value) > 0)
            {
                return Delete(node.Left, value);
            }
            else
            {
                // BST Delete
                if (node.Left == null)
                {
                    node = node.Right;
                }
                else if (node.Right == null)
                {
                    node = node.Left;
                }
                else
                {
                    node.Value = GetMinValue(node.Right);
                    Delete(node.Right, node.Value);
                }

                // AVL Rebalance
                var nodeHeightDiff = GetHeightDifference(node);
                if (nodeHeightDiff > 1)
                {
                    var leftNodeHeight = GetHeightDifference(node.Left);
                    if (leftNodeHeight < 0)
                    {
                        // Left Right
                        node.Left = RotateLeft(node.Left);
                    }

                    // Left Left
                    return RotateRight(node);
                }
                else if (nodeHeightDiff < -1)
                {
                    var rightNodeDiff = GetHeightDifference(node.Right);
                    if (rightNodeDiff > 0)
                    {
                        // Right Left
                        node.Right = RotateRight(node.Right);
                    }

                    // Right Right
                    return RotateLeft(node);
                }

                return node;
            }
        }

        public T GetMaxValue()
        {
            if (Root == null)
            {
                throw new Exception("Tree is empty.");
            }
            else
            {
                return GetMaxValue(Root);
            }

        }

        private T GetMaxValue(AVLNode<T> node)
        {
            if (node.Right == null)
            {
                return node.Value;
            }
            else
            {
                return GetMaxValue(node.Right);
            }
        }

        public T GetMinValue()
        {
            if (Root == null)
            {
                throw new Exception("Tree is empty.");
            }
            else
            {
                return GetMinValue(Root);
            }
        }

        private T GetMinValue(AVLNode<T> node)
        {
            if (node.Left == null)
            {
                return node.Value;
            }
            else
            {
                return GetMinValue(node.Left);
            }
        }

        public AVLNode<T> GetNode(T value)
        {
            return GetNode(Root, value);
        }

        public AVLNode<T> GetNode(AVLNode<T> node, T value)
        {
            if (node == null)
            {
                return null;
            }
            else if (node.Value.CompareTo(value) == 0)
            {
                return node;
            }
            else if (node.Value.CompareTo(value) < 0)
            {
                return GetNode(node.Right, value);
            }
            else
            {
                return GetNode(node.Left, value);
            }
        }

        public AVLNode<T> Insert(T value)
        {
            if (Root == null)
            {
                Root = new AVLNode<T>(value);
                return Root;
            }
            else
            {
                return Insert(Root, value);
            }
        }

        public AVLNode<T> Insert(AVLNode<T> node, T value)
        {
            if (node == null)
            {
                return new AVLNode<T>(value);
            }
            else if (node.Value.CompareTo(value) < 0)
            {
                node.Right = Insert(node.Right, value);
            }
            else if (node.Value.CompareTo(value) > 0)
            {
                node.Left = Insert(node.Left, value);
            }
            else
            {
                return node;
            }

            var heightDiff = GetHeightDifference(node);
            if (heightDiff > 1)
            {
                var leftNodeHeight = GetHeightDifference(node.Left);
                if (leftNodeHeight < 0)
                {
                    // Left Right
                    node.Left = RotateLeft(node.Left);

                }

                // Left left
                return RotateRight(node);
            }
            else if (heightDiff < -1)
            {
                var rightNodeHeight = GetHeightDifference(node.Right);
                if (rightNodeHeight > 0)
                {
                    // Right Left
                    node.Right = RotateRight(node.Right);
                }

                // Right right
                return RotateLeft(node);
            }

            return node;
        }

        private int GetHeight(AVLNode<T> node)
        {
            if (node == null)
            {
                return 0;
            }
            else
            {
                return node.Height;
            }
        }

        public int GetHeightDifference(AVLNode<T> node)
        {
            if (node == null)
            {
                return 0;
            }
            else
            {
                return GetHeight(node.Left) - GetHeight(node.Right);
            }
        }

        public AVLNode<T> RotateLeft(AVLNode<T> node)
        {
            var headLeft = node;
            var head = headLeft.Right;
            var headLeftRight = head.Left;

            head.Left = headLeft;
            headLeft.Right = headLeftRight;

            headLeft.Height = Math.Max(headLeft.Left.Height, headLeft.Right.Height) + 1;
            head.Height = Math.Max(head.Left.Height, head.Right.Height) + 1;

            return head;
        }

        public AVLNode<T> RotateRight(AVLNode<T> node)
        {
            var headRight = node;
            var head = node.Left;
            var headRightLeft = node.Left.Right;

            head.Right = headRight;
            headRight.Left = headRightLeft;

            headRight.Height = Math.Max(headRight.Left.Height, headRight.Right.Height) + 1;
            head.Height = Math.Max(head.Left.Height, head.Right.Height) + 1;

            return head;
        }
    }
}
