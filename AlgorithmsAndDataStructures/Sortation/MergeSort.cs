using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsAndDataStructures.Algorithms.Sortation
{
    public class MergeSort<T> : ISortable<T> where T: IComparable<T>
    {
        public T[] Sort(T[] items)
        {
            if (items == null || items.Length <= 1)
            {
                return items;
            }

            T[] mem = new T[items.Length];
            SortWithMemory(items, mem, 0, items.Length - 1);
            return items;
        }

        private void SortWithMemory(T[] items, T[] mem, int leftIndex, int rightIndex)
        {
            if (leftIndex < rightIndex)
            {
                int middle = (rightIndex + leftIndex) / 2;
                SortWithMemory(items, mem, leftIndex, middle);
                SortWithMemory(items, mem, middle + 1, rightIndex);
                Merge(items, mem, leftIndex, middle, rightIndex);
            }
        }

        private void Merge(T[] items, T[] mem, int leftIndex, int middleIndex, int rightIndex)
        {
            for (int i = leftIndex; i <= rightIndex; i++)
            {
                mem[i] = items[i];
            }

            var left = leftIndex;
            var right = middleIndex + 1;
            var current = left;

            while (left <= middleIndex && right <= rightIndex )
            {
                    if (mem[left].CompareTo(mem[right]) <= 0)
                    {
                        items[current] = mem[left];
                        left++;
                    }
                    else
                    {
                        items[current] = mem[right];
                        right++;
                    }
                    current++;
            }

            while (left <= middleIndex)
            {
                items[current] = mem[left];
                left++;
                current++;
            }
        }
    }
}
