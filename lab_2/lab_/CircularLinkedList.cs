using System;
using System.Collections;
using System.Collections.Generic;

namespace lab_
{
    public class CircularLinkedList<T> : IEnumerable<T>
    {
        private Node<T> head;
        private Node<T> tail;
        public int Count { get; private set; }

        // События для отслеживания изменений в списке
        public event EventHandler ItemAdded;
        public event EventHandler ItemRemoved;
        public event EventHandler ListCleared;

        public void Add(T item)
        {
            var node = new Node<T>(item);
            if (head == null)
            {
                head = node;
                tail = node;
                tail.Next = head; // Making it circular
            }
            else
            {
                node.Next = head;
                tail.Next = node;
                tail = node;
            }
            Count++;
            ItemAdded?.Invoke(this, EventArgs.Empty); // Событие добавления элемента
        }

        public bool Remove(T item)
        {
            if (head == null) return false; // Пустой список

            Node<T> current = head;
            Node<T> previous = null;
            do
            {
                if (current.Value.Equals(item))
                {
                    if (previous != null)
                    {
                        previous.Next = current.Next;
                        if (current == tail) // Если удаляем последний элемент
                        {
                            tail = previous;
                        }
                    }
                    else
                    {
                        if (Count == 1) // Если в списке только один элемент
                        {
                            head = tail = null;
                        }
                        else
                        {
                            head = current.Next;
                            tail.Next = head;
                        }
                    }
                    Count--;
                    ItemRemoved?.Invoke(this, EventArgs.Empty); // Событие удаления элемента
                    return true;
                }
                previous = current;
                current = current.Next;
            } while (current != head);

            return false;
        }

        public bool Contains(T item)
        {
            Node<T> current = head;
            if (current == null) return false;

            do
            {
                if (current.Value.Equals(item)) return true;
                current = current.Next;
            } while (current != head);

            return false;
        }

        public void Clear()
        {
            head = null;
            tail = null;
            Count = 0;
            ListCleared?.Invoke(this, EventArgs.Empty); // Событие очистки списка
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node<T> current = head;
            if (current != null)
            {
                do
                {
                    yield return current.Value;
                    current = current.Next;
                } while (current != head);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
