using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using AlgorithmsAndDataStructures.DataStructures.Lists;


namespace AlgorithmsAndDataStructuresUnitTest.DataStructures.Lists
{

    class LinkListTests
    {
        private LinkedList<int> CreateEmptyLinkList()
        {
            return new LinkedList<int>();
        }

        private LinkedList<int> CreateNotEmptyLinkList(int[] values)
        {
            LinkedList<int> notEmptyLinkList = new LinkedList<int>();
            for (int i = 0; i < values.Length; i++)
            {
                notEmptyLinkList.AddLast(values[i]);
            }
            return notEmptyLinkList;
        }

        [Test]
        public void GetFirst_AddFirst_GetMatchingValue()
        {
            int value = 10;
            int value2 = 20;
            int value3 = 30;
            LinkedList<int> testLinkList = CreateNotEmptyLinkList(new int[] { value2, value3 });

            testLinkList.AddFirst(value);

            Assert.AreEqual(value, testLinkList.GetFirst());
        }

        [Test]
        public void GetFirst_AddFirstRemoveFirst_GetMatchingValue()
        {
            int value = 10;
            int value2 = 20;
            int value3 = 30;
            LinkedList<int> testLinkList = CreateNotEmptyLinkList(new int[] { value2, value3 });

            testLinkList.AddFirst(value);
            testLinkList.RemoveFirst();

            Assert.AreEqual(value2, testLinkList.GetFirst());
        }

        [Test]
        public void GetFirst_NoNode_ThrowsException()
        {
            LinkedList<int> testLinkList = CreateNotEmptyLinkList(new int[] { });

            Assert.Throws(typeof(Exception), () => testLinkList.GetFirst());
        }

        [Test]
        public void GetLast_AddLast_GetMatchingValue()
        {
            int value = 10;
            int value2 = 20;
            int value3 = 30;
            LinkedList<int> testLinkList = CreateNotEmptyLinkList(new int[] { value, value2 });

            testLinkList.AddLast(value3);

            Assert.AreEqual(value3, testLinkList.GetLast());
        }


        [Test]
        public void GetLast_AddLastRemoveLast_GetMatchingValue()
        {
            int value = 10;
            int value2 = 20;
            int value3 = 30;
            LinkedList<int> testLinkList = CreateNotEmptyLinkList(new int[] { value, value2 });

            testLinkList.AddLast(value3);
            testLinkList.RemoveLast();

            Assert.AreEqual(value2, testLinkList.GetLast());
        }

        [Test]
        public void GetLast_NoNode_ThrowsException()
        {
            LinkedList<int> testLinkList = CreateNotEmptyLinkList(new int[] { });

            Assert.Throws(typeof(Exception), () => testLinkList.GetLast());
        }

        [Test]
        public void Clear_WithNodes_GetZeroCount()
        {
            int value = 10;
            int value2 = 20;
            int value3 = 30;
            LinkedList<int> testLinkList = CreateNotEmptyLinkList(new int[] { value, value2, value3 });

            testLinkList.Clear();

            Assert.AreEqual(0, testLinkList.Count);
        }

        [Test] 
        public void Contains_HasValue_True()
        {
            int value = 10;
            int value2 = 20;
            int value3 = 30;
            LinkedList<int> testLinkList = CreateNotEmptyLinkList(new int[] { value, value2, value3 });

            Assert.True(testLinkList.Contains(value));
        }

        [Test]
        public void Contains_DoesNotHaveValue_False()
        {
            LinkedList<int> testLinkList = CreateNotEmptyLinkList(new int[] { });

            Assert.False(testLinkList.Contains(10));
        }


    }
}
