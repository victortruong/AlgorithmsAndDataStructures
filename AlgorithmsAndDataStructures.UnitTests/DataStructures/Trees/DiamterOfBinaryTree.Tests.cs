using System;
using NUnit.Framework;
using AlgorithmsAndDataStructures.DataStructures;
using AlgorithmsAndDataStructures.DataStructures.Trees;


namespace AlgorithmsAndDataStructuresUnitTests.DataStructures.Trees
{
    [TestFixture]
    public class DiamterOfBinaryTreeTest
    {

        [Test]
        public void GetHeight_ThroughRoot_Value9()
        {
            var test = new BinaryNode<int>(61);
            test.Left = new BinaryNode<int>(51);
            test.Right = new BinaryNode<int>(52);
            test.Left.Left = new BinaryNode<int>(41);
            test.Left.Right = new BinaryNode<int>(42);
            test.Right.Right = new BinaryNode<int>(43);
            test.Left.Right.Left = new BinaryNode<int>(31);
            test.Left.Right.Left.Right = new BinaryNode<int>(21);
            test.Right.Right.Left = new BinaryNode<int>(32);
            test.Right.Right.Right = new BinaryNode<int>(33);
            test.Right.Right.Right.Left = new BinaryNode<int>(22);

            var actualResult = DiameterOfBinaryTree<int>.GetHeight(test);
            Assert.AreEqual(9, actualResult);
        }

        [Test]
        public void GetHeight_NotThroughRoot_Value9()
        {
            var test = new BinaryNode<int>(70);
            test.Left = new BinaryNode<int>(61);
            test.Right = new BinaryNode<int>(62);
            test.Left.Left = new BinaryNode<int>(51);
            test.Left.Right = new BinaryNode<int>(52);
            test.Left.Left.Left = new BinaryNode<int>(41);
            test.Left.Left.Right = new BinaryNode<int>(42);
            test.Left.Right.Right = new BinaryNode<int>(43);
            test.Left.Left.Right.Left = new BinaryNode<int>(31);
            test.Left.Left.Right.Left.Right = new BinaryNode<int>(21);
            test.Left.Right.Right.Left = new BinaryNode<int>(32);
            test.Left.Right.Right.Right = new BinaryNode<int>(33);
            test.Left.Right.Right.Right.Left = new BinaryNode<int>(22);

            var actualResult = DiameterOfBinaryTree<int>.GetHeight(test);
            Assert.AreEqual(9, actualResult);
        }
    }
}
