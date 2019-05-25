using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsAndDataStructures.DataStructures
{
    interface ILinkList<T> where T: IComparable<T>
    {
        int Count { get;  }

        void AddFirst(T value);

        void AddLast(T value);

        void Remove(T value);

        void RemoveFirst();

        void RemoveLast();

        void Clear();

        T GetFirst();

        T GetLast();

        bool Contains(T value);


    }
}
