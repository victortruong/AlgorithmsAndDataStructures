using System;
namespace AlgorithmsAndDataStructures.DataStructures.Trees
{
    public static class DiameterOfBinaryTree<T> where T: IComparable<T>
    {
        public static int GetHeight(BinaryNode<T> root)
        {
            var height = new Height();
            return GetBinaryTreeDiameter(root, height);
        }

        private class Height
        {
            public int Value { get; set; }
        }

        private static int GetBinaryTreeDiameter(BinaryNode<T> node, Height height)
        {
            if (node == null)
            {
                height.Value = 0;
                return 0;
            }

            var leftHeight = new Height();
            var rightHeight = new Height();

            int leftDiameter = GetBinaryTreeDiameter(node.Left, leftHeight);
            int rightDiameter = GetBinaryTreeDiameter(node.Right, rightHeight);

            height.Value = 1 + Math.Max(leftHeight.Value, rightHeight.Value);

            return Math.Max(leftHeight.Value + rightHeight.Value + 1, Math.Max(leftDiameter, rightDiameter));

        }
    }
}
