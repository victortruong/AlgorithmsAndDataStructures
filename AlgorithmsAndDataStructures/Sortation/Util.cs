using System;

namespace AlgorithmsAndDataStructures.Algorithms.Sortation
{
    public class Util
    {
        public static void Swap<T>(T[] items, int leftIndex, int rightIndex)
        {
            T temp = items[leftIndex];
            items[leftIndex] = items[rightIndex];
            items[rightIndex] = temp;
        }
    }
}
