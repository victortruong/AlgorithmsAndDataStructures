using System;

namespace AlgorithmsAndDataStructures.Algorithms.Sortation
{
    public interface ISortable<T> where T: IComparable<T>
    {
        T[] Sort(T[] items);
    }
}
