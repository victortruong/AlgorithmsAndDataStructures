using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using AlgorithmsAndDataStructures.Algorithms.Sortation;


namespace AlgorithmsAndDataStructuresUnitTests.Sortation
{
    [TestFixtureSource("SortableParams")]
    class ISortableTests
    {
        private ISortable<int> SortAlgorithm { get; set; }

        public ISortableTests(ISortable<int> sortAlgorithm)
        {
            SortAlgorithm = sortAlgorithm;
        }

        private static IEnumerable<TestFixtureData> SortableParams()
        {
            yield return new TestFixtureData(new BubbleSort<int>());
            yield return new TestFixtureData(new MergeSort<int>());
            yield return new TestFixtureData(new QuickSort<int>());
            yield return new TestFixtureData(new SelectionSort<int>());
            yield return new TestFixtureData(new CountingSort());
            yield return new TestFixtureData(new RadixSort());
        }

        private static int[] GetSortedItems()
        {
            return new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        }

        private static int[] GetRandomOrderItems()
        {
            var random = new List<int>();
            var rng = new Random();
            for (int i = 0; i < 100; i++)
            {
                random.Add(rng.Next() % 1000);
            }

            return random.ToArray();
        }

        private static int[] GetReverseSortedItems()
        {
            return new int[] { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 };
        }

        [Test]
        public void Sort_Null()
        {
            int[] items = null;
            int[] sortedItems = SortAlgorithm.Sort(items);

            Assert.IsNull(sortedItems);
        }

        [Test]
        public void Sort_NoItems()
        {
            var items = new int[] { };
            int[] sortedItems = SortAlgorithm.Sort(items);

            Assert.True(Enumerable.SequenceEqual(items, sortedItems));

        }

        [Test]
        public void Sort_SingleItem()
        {
            var items = new int[] { 1 };
            int[] sortedItems = SortAlgorithm.Sort(items);

            Assert.True(Enumerable.SequenceEqual(items, sortedItems));
        }

        [Test]
        public void Sort_SortedOrder()
        {
            int[] items = GetSortedItems();
            int[] sortedItems = SortAlgorithm.Sort(items);

            Assert.True(Enumerable.SequenceEqual(items, sortedItems));
        }

        [Test]
        public void Sort_RandomOrder()
        {
            int[] items = GetRandomOrderItems();
            int[] sortedItems = SortAlgorithm.Sort(items);

            int[] sortedResults = items.OrderBy(item => item).ToArray(); 

            Assert.True(Enumerable.SequenceEqual(sortedResults, sortedItems));
        }

        [Test]
        public void Sort_ReverseSortedOrder()
        {
            int[] items = GetReverseSortedItems();
            int[] sortedItems = SortAlgorithm.Sort(items);

            int[] sortedResults = GetSortedItems();

            Assert.True(Enumerable.SequenceEqual(sortedResults, sortedItems));
        }
    }
}
