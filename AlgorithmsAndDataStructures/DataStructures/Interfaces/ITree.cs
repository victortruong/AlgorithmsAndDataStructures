using System;

namespace AlgorithmsAndDataStructures.DataStructures.Interfaces
{
    public interface ITree<T, TNode> where T: IComparable<T> where TNode: Node<T>
    {   
        TNode Root { get; set; }

        TNode Insert(T value);

        TNode Delete(T value);

        TNode GetNode(T value);

        T GetMaxValue();

        T GetMinValue();
    }
}
