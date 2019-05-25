using System;

namespace AlgorithmsAndDataStructures.Algorithms.Sortation
{
    public class CountingSort : ISortable<int>
    {
        private const int ArraySize = 1001;

        public int[] Sort(int[] items)
        {
            if (items == null || items.Length <= 1)
            {
                return items;
            }

            var counter = new int[ArraySize];

            for (int i = 0; i < items.Length; i++)
            {
                var index = GetIndex(items[i]);
                counter[index]++;
            }

            for (int i = 1; i < counter.Length; i++)
            {
                counter[i] += counter[i - 1];
            }

            var result = new int[items.Length];

            for (int i = 0; i < items.Length; i++)
            {
                var value = items[i];
                var valueIndex = GetIndex(value);
                var index = counter[valueIndex] - 1;
                counter[valueIndex]--;
                result[index] = value;
            }

            return result;
        }

        private int GetIndex(int item)
        {

            return item.GetHashCode() % ArraySize;
        }
    }
}
