using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsAndDataStructures.Algorithms.Sortation
{
    public class QuickSort<T> : ISortable<T> where T : IComparable<T>
    {
        public T[] Sort(T[] items)
        {
            if (items == null || items.Length <= 1)
            {
                return items;
            }

            Sort(items, 0, items.Length - 1);
            return items;
        }

        private void Sort(T[] items, int leftIndex, int rightIndex)
        {
            int index = Partition(items, leftIndex, rightIndex);

            if (leftIndex < index - 1)
            {
                Sort(items, leftIndex, index - 1);
            }
            if (index <rightIndex)
            {
                Sort(items, index, rightIndex);
            }
        }

        private int Partition(T[] items, int leftIndex, int rightIndex)
        {
            T pivot = items[(leftIndex + rightIndex) / 2];

            while (leftIndex <= rightIndex)
            {
                while (items[leftIndex].CompareTo(pivot) < 0)
                {
                    leftIndex++;
                }

                while (items[rightIndex].CompareTo(pivot) > 0)
                {
                    rightIndex--;
                }

                if (leftIndex <= rightIndex)
                {
                    Util.Swap(items, leftIndex, rightIndex);
                    leftIndex++;
                    rightIndex--;
                }
            }


            return leftIndex;
        }
    }
}
