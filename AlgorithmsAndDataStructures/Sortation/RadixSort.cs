using System;

namespace AlgorithmsAndDataStructures.Algorithms.Sortation
{
    public class RadixSort : ISortable<int>
    {
        public int[] Sort(int[] items)
        {
            if (items == null || items.Length <= 1)
            {
                return items;
            }

            var maxValue = GetMax(items);

            for (int exp = 1; maxValue / exp > 0; exp *= 10)
            {
                items = CountingSort(items, exp);
            }
            return items;
        }

        private int GetMax(int[] items)
        {
            var max = -1;
            for (int i = 0; i < items.Length; i++)
            {
                max = Math.Max(max, items[i]);
            }
            return max;
        }

        private int[] CountingSort(int[] items, int exp)
        {
            var counter = new int[10];

            for (int i = 0; i < items.Length; i++)
            {
                var itemValue = CalculateItemValue(items[i], exp);
                counter[itemValue]++;
            }

            for (int i = 1; i < counter.Length; i++)
            {
                counter[i] += counter[i - 1];
            }

            var result = new int[items.Length];

            for (int i = items.Length - 1; i >= 0; i--)
            {
                var itemValue = CalculateItemValue(items[i], exp);
                var itemIndex = counter[itemValue] - 1;
                counter[itemValue]--;
                result[itemIndex] = items[i];
            }

            return result;
        }

        private int CalculateItemValue(int item,int exp)
        {
            return (int) (item / exp) % 10;
        }

    }
}
