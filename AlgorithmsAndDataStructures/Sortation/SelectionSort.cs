using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsAndDataStructures.Algorithms.Sortation
{
    public class SelectionSort<T> : ISortable<T> where T : IComparable<T>
    {
        public T[] Sort(T[] items)
        {
            if (items == null || items.Length <= 1)
            {
                return items;   
            }

            for (int i = 0; i < items.Length; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < items.Length; j++)
                {
                    if (items[minIndex].CompareTo(items[j]) > 0)
                    {
                        minIndex = j;
                    }
                }

                Util.Swap(items, i, minIndex);
            }

            return items;
        }
    }
}
