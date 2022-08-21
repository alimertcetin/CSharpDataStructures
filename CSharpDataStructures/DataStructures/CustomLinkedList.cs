using System.Collections;
using System.Collections.Generic;

namespace XIV.DataStructures
{
    public class Node<T>
    {
        public T value;
        public Node<T> next;
        public Node<T> previous;

        public Node(T value)
        {
            this.value = value;
        }

        public Node(T value, Node<T> next, Node<T> previous)
        {
            this.value = value;
            this.next = next;
            this.previous = previous;
        }

        public override string ToString()
        {
            return value.ToString();
        }
    }

    public class CustomLinkedList<T> : IEnumerable<Node<T>>
    {
        public Node<T> head { get; private set; }
        public Node<T> last { get; private set; }

        public int Count;

        public CustomLinkedList()
        {

        }

        public CustomLinkedList(IEnumerable<T> collection)
        {
            foreach (var item in collection)
            {
                AddLast(item);
            }
        }

        public void AddLast(T value)
        {
            Count++;
            if (head == null)
            {
                head = new Node<T>(value);
                last = head;
                return;
            }

            var newNode = new Node<T>(value);
            newNode.previous = last;
            last.next = newNode;
            last = newNode;
        }

        public void AddFirst(T value)
        {
            Count++;
            if (head == null)
            {
                head = new Node<T>(value);
                last = head;
                return;
            }

            var newNode = new Node<T>(value);
            newNode.next = head;
            head.previous = newNode;
            head = newNode;
        }

        public void AddAfter(Node<T> node, T item)
        {
            Count++;

            var newNode = new Node<T>(item);
            newNode.previous = node;
            newNode.next = node.next;
            node.next = newNode;

            if (newNode.next != null) newNode.next.previous = newNode;

            if (node == last)
            {
                last = newNode;
            }
        }

        public void AddBefore(Node<T> node, T item)
        {
            Count++;

            var newNode = new Node<T>(item);
            newNode.next = node;
            newNode.previous = node.previous;
            node.previous = newNode;

            if (newNode.previous != null) newNode.previous.next = newNode;

            if (node == head)
            {
                head = newNode;
            }
        }

        public bool Contains(T item)
        {
            var current = head;
            while (current.next != null)
            {
                if (current.value.Equals(item)) return true;

                current = current.next;
            }
            return false;
        }

        public Node<T> Find(T item)
        {
            var current = head;
            while (current.next != null)
            {
                if (current.value.Equals(item))
                {
                    return current;
                }

                current = current.next;
            }
            return null;
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public IEnumerator<Node<T>> GetEnumerator() => new CustomLinkedListEnumerator(this);

        struct CustomLinkedListEnumerator : IEnumerator<Node<T>>
        {
            public Node<T> Current { get; private set; }

            object IEnumerator.Current => Current;

            CustomLinkedList<T> linkedList;

            public CustomLinkedListEnumerator(CustomLinkedList<T> list)
            {
                this.linkedList = list;
                Current = null;
            }

            public void Dispose()
            {
                linkedList = null;
                Current = null;
            }

            public bool MoveNext()
            {
                Current = Current == null ? linkedList.head : Current.next;

                return Current != null;
            }

            public void Reset()
            {
                Current = null;
            }
        }
    }
}
