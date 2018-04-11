using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ChainList
{
    class ChainList<T> : IEnumerable<T>
    {
        private Node<T> root;

        public ChainList()
        {
            root = new Node<T>(default(T));
            root.Next = root;
            root.Previous = root;
        }

        public void Add(T value)
        {
            Node<T> newElement = new Node<T>(value, root.Previous, root);

            root.Previous.Next = newElement;
            root.Previous = newElement;
        }

        public void AddFirst(T value)
        {
            Node<T> newElement = new Node<T>(value, root, root.Next);

            root.Next.Previous = newElement;
            root.Next = newElement;
        }

        public void InsertAt(int index, T value)
        {
            var current = root.Next;
            int currentIndex = 0;

            while (currentIndex != index && current != root)
            {
                current = current.Next;
                currentIndex++;
            }

            if (current == root)
            {
                throw new ArgumentOutOfRangeException();
            }

            Node<T> newElement = new Node<T>(value, current, current.Next);

            current.Next = newElement;
            current.Next.Previous = newElement;

        }

        public void Delete(T value)
        {
            Node<T> current = root.Next;

            while (!current.Value.Equals(value) && current != root)
            {
                current = current.Next;
            }

            if (current == root)
            {
                return;
            }

            current.Previous.Next = current.Next;
            current.Next.Previous = current.Previous;
        }

        public Node<T> FindFromBeggining(T value)
        {
            Node<T> current = root.Next;
            while (!current.Value.Equals(value) && current != root)
            {
                current = current.Next;
            }
            return current;
        }

        public Node<T> FindFromEnd(T value)
        {
            Node<T> current = root.Previous;
            while (!current.Value.Equals(value) && current != root)
            {
                current = current.Previous;
            }
            return current;
        }

        public IEnumerable<T> GetReverseEnumerator()
        {
            var current = root.Previous;
            while (current != root)
            {
                yield return current.Value;
                current = current.Previous;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            var current = root.Next;
            while (current != root)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
