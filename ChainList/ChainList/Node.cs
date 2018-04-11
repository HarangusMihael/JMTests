using System;
using System.Collections.Generic;
using System.Text;

namespace ChainList
{
    class Node<T>
    {
       public T Value;
       public Node<T> Previous;
       public Node<T> Next;

        public Node(T value, Node<T> previous = null, Node<T> next = null)
        {
            Value = value;
            Previous = previous;
            Next = next;
        }
    }
}
