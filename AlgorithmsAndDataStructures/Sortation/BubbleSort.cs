using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsAndDataStructures.Algorithms.Sortation
{
    public class BubbleSort<T> : ISortable<T> where T:IComparable<T>
    {
        public T[] Sort(T[] items)
        {
            if (items == null || items.Length <= 1)
            {
                return items;
            }

            for (int i = items.Length - 1; i >= 0; i--)
            {
                bool swapped = false;
                for (int j = 0; j < i; j++)
                {
                    if (items[j].CompareTo(items[j+1]) > 0) {
                        Util.Swap(items, j, j + 1);
                        swapped = true;
                    }
                }

                if (!swapped)
                {
                    break;
                }
            }
            return items;
        }
    }
}
