using System;
using NUnit.Framework;
using AlgorithmsAndDataStructures.DataStructures;
using AlgorithmsAndDataStructures.DataStructures.Trees;

namespace AlgorithmsAndDataStructuresUnitTests.DataStructures.Trees
{
    [TestFixture]
    public class BinaryTreeTests
    {
        private BinaryTree<int> EmptyTree;
        private BinaryTree<int> PopulatedTree;

        [OneTimeSetUp]
        public void ClassInit()
        {
            PopulatedTree = new BinaryTree<int>();
            EmptyTree = new BinaryTree<int>();
        }

        [SetUp]
        public void TestInit()
        {
            var root = new BinaryNode<int>(50); ;
            root.Left = new BinaryNode<int>(30);
            root.Left.Left = new BinaryNode<int>(20);
            root.Left.Right = new BinaryNode<int>(40);
            root.Right = new BinaryNode<int>(70);
            root.Right.Left = new BinaryNode<int>(60);
            root.Right.Right = new BinaryNode<int>(80);

            PopulatedTree.Root = root;
        }

        [Test]
        public void Delete_ValueNotInTree_TreeNotChanged()
        {
            // Arrange
            var root = new BinaryNode<int>(50); ;
            root.Left = new BinaryNode<int>(30);
            root.Left.Left = new BinaryNode<int>(20);
            root.Left.Right = new BinaryNode<int>(40);
            root.Right = new BinaryNode<int>(70);
            root.Right.Left = new BinaryNode<int>(60);
            root.Right.Right = new BinaryNode<int>(80);

            var expectedTree = new BinaryTree<int>();
            expectedTree.Root = root;


            // Act
            PopulatedTree.Delete(100);

            // Assert
            Assert.AreEqual(expectedTree.Root.Value, PopulatedTree.Root.Value);
            Assert.AreEqual(expectedTree.Root.Left.Value, PopulatedTree.Root.Left.Value);
            Assert.AreEqual(expectedTree.Root.Left.Left.Value, PopulatedTree.Root.Left.Left.Value);
            Assert.AreEqual(expectedTree.Root.Left.Right.Value, PopulatedTree.Root.Left.Right.Value);
            Assert.AreEqual(expectedTree.Root.Right.Value, PopulatedTree.Root.Right.Value);
            Assert.AreEqual(expectedTree.Root.Right.Left.Value, PopulatedTree.Root.Right.Left.Value);
            Assert.AreEqual(expectedTree.Root.Right.Right.Value, PopulatedTree.Root.Right.Right.Value);
        }

        [Test]
        public void Delete_NodeWithNoLeftAndRight_TreeUpdated()
        {
            // Arrange
            var root = new BinaryNode<int>(50);
            root.Left = new BinaryNode<int>(30);
            root.Left.Left = new BinaryNode<int>(20);
            root.Left.Right = new BinaryNode<int>(40);
            root.Right = new BinaryNode<int>(70);
            root.Right.Right = new BinaryNode<int>(80);

            var expectedTree = new BinaryTree<int>();
            expectedTree.Root = root;

            // Act
            PopulatedTree.Delete(60);

            // Assert
            Assert.AreEqual(expectedTree.Root.Value, PopulatedTree.Root.Value);
            Assert.AreEqual(expectedTree.Root.Right.Value, PopulatedTree.Root.Right.Value);
            Assert.IsNull(PopulatedTree.Root.Right.Left);
            Assert.AreEqual(expectedTree.Root.Right.Right.Value, PopulatedTree.Root.Right.Right.Value);
        }

        [Test]
        public void Delete_NodeWithNoLeft_TreeUpdated()
        {
            // Arrange
            var root = new BinaryNode<int>(50); ;
            root.Left = new BinaryNode<int>(30);
            root.Left.Left = new BinaryNode<int>(20);
            root.Left.Right = new BinaryNode<int>(40);
            root.Right = new BinaryNode<int>(70);
            root.Right.Left = new BinaryNode<int>(65);
            root.Right.Right = new BinaryNode<int>(80);

            var expectedTree = new BinaryTree<int>();
            expectedTree.Root = root;

            PopulatedTree.Root.Right.Left.Right = new BinaryNode<int>(65);

            // Act
            PopulatedTree.Delete(60);

            // Assert
            Assert.AreEqual(expectedTree.Root.Value, PopulatedTree.Root.Value);
            Assert.AreEqual(expectedTree.Root.Right.Value, PopulatedTree.Root.Right.Value);
            Assert.AreEqual(expectedTree.Root.Right.Left.Value, PopulatedTree.Root.Right.Left.Value);
            Assert.AreEqual(expectedTree.Root.Right.Right.Value, PopulatedTree.Root.Right.Right.Value);
        }

        [Test]
        public void Delete_NodeWithNoRight_TreeUpdated()
        {
            // Arrange
            var root = new BinaryNode<int>(50); ;
            root.Left = new BinaryNode<int>(30);
            root.Left.Left = new BinaryNode<int>(20);
            root.Left.Right = new BinaryNode<int>(40);
            root.Right = new BinaryNode<int>(70);
            root.Right.Left = new BinaryNode<int>(55);
            root.Right.Right = new BinaryNode<int>(80);

            var expectedTree = new BinaryTree<int>();
            expectedTree.Root = root;

            PopulatedTree.Root.Right.Left.Left = new BinaryNode<int>(55);

            // Act
            PopulatedTree.Delete(60);

            // Assert
            Assert.AreEqual(expectedTree.Root.Value, PopulatedTree.Root.Value);
            Assert.AreEqual(expectedTree.Root.Right.Value, PopulatedTree.Root.Right.Value);
            Assert.AreEqual(expectedTree.Root.Right.Left.Value, PopulatedTree.Root.Right.Left.Value);
            Assert.AreEqual(expectedTree.Root.Right.Right.Value, PopulatedTree.Root.Right.Right.Value);
        }

        [Test]
        public void Delete_NodeWithLeftAndRight_TreeUpdated()
        {
            // Arrange
            var root = new BinaryNode<int>(60); ;
            root.Left = new BinaryNode<int>(30);
            root.Left.Left = new BinaryNode<int>(20);
            root.Left.Right = new BinaryNode<int>(40);
            root.Right = new BinaryNode<int>(70);
            root.Right.Right = new BinaryNode<int>(80);

            var expectedTree = new BinaryTree<int>();
            expectedTree.Root = root;


            // Act
            PopulatedTree.Delete(50);

            // Assert
            Assert.AreEqual(expectedTree.Root.Value, PopulatedTree.Root.Value);
            Assert.AreEqual(expectedTree.Root.Right.Value, PopulatedTree.Root.Right.Value);
            Assert.IsNull(PopulatedTree.Root.Right.Left);
            Assert.AreEqual(expectedTree.Root.Right.Right.Value, PopulatedTree.Root.Right.Right.Value);
        }

        [Test]
        public void GetMinValue_EmptyTree_ThrowsException()
        {
            // Assert
            Assert.Throws(typeof(Exception), () => EmptyTree.GetMinValue());
        }

        [Test]
        public void GetMinValue_PopulatedTree_Returns20()
        {
            // Act
            var minValue = PopulatedTree.GetMinValue();

            // Assert
            Assert.AreEqual(20, minValue);
        }

        [Test]
        public void GetMaxValue_EmptyTree_ThrowsException()
        {
            // Assert
            Assert.Throws(typeof(Exception), () => EmptyTree.GetMaxValue());
        }

        [Test]
        public void GetMaxValue_PopulatedTree_Returns80()
        {
            // Act
            var maxValue = PopulatedTree.GetMaxValue();

            // Assert
            Assert.AreEqual(80, maxValue);
        }

        [Test]
        public void GetNode_ValueDoesNotExist_ReturnsNull()
        {
            // Act
            var node = PopulatedTree.GetNode(65);

            Assert.IsNull(node);
        }

        [Test]
        public void GetNode_ValueExist_ReturnsNode()
        {
            // Act
            var node = PopulatedTree.GetNode(70);

            // Assert
            Assert.AreEqual(70, node.Value);
        }

        [Test]
        public void Insert_EmptyTree_ValueIsRoot()
        {
            // Arrange
            var testTree = new BinaryTree<int>();

            // Act
            testTree.Insert(1);

            // Assert
            Assert.AreEqual(1, testTree.Root.Value);
        }

        [Test]
        public void Insert_PopulatedTree_ValueIsInserted()
        {
            // Act
            PopulatedTree.Insert(35);

            // Assert
            Assert.AreEqual(35, PopulatedTree.Root.Left.Right.Left.Value);
        }
    }
}
