using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace lab_1
{
    internal class RingBuffer<T> : IEnumerable<T>
    {
        private RingNode<T> tail;
        private int count;

        // События с информацией об элементе
        public event EventHandler<T> ItemAdded;
        public event EventHandler<T> ItemRemoved;

        public RingBuffer()
        {
            tail = null;
            count = 0;
        }

        public void Append(T value)
        {
            RingNode<T> node = new RingNode<T>(value);
            if (tail == null)
            {
                tail = node;
                tail.Next = tail; // Кольцевая ссылка на самого себя
            }
            else
            {
                node.Next = tail.Next;
                tail.Next = node;
                tail = node; // Обновляем указатель на последний добавленный элемент
            }
            count++;
            OnItemAdded(value);
        }

        public bool Detach(T value)
        {
            if (tail == null) throw new InvalidOperationException("Cannot detach from an empty buffer.");

            RingNode<T> current = tail.Next;
            RingNode<T> previous = tail;
            bool isDetached = false;

            do
            {
                if (current.Value.Equals(value))
                {
                    if (current == tail)
                    {
                        if (count == 1)
                        {
                            tail = null;
                        }
                        else
                        {
                            previous.Next = current.Next;
                            tail = previous;
                        }
                    }
                    else
                    {
                        previous.Next = current.Next;
                    }

                    count--;
                    isDetached = true;
                    OnItemRemoved(value);
                    break;
                }

                previous = current;
                current = current.Next;
            } while (current != tail.Next);

            return isDetached;
        }

        protected virtual void OnItemAdded(T item)
        {
            ItemAdded?.Invoke(this, item);
        }

        protected virtual void OnItemRemoved(T item)
        {
            ItemRemoved?.Invoke(this, item);
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            foreach (var item in this)
            {
                builder.Append(item.ToString() + " ");
            }
            return builder.ToString().TrimEnd();
        }

        public IEnumerator<T> GetEnumerator()
        {
            RingNode<T> current = tail?.Next;
            if (current == null) yield break;

            do
            {
                yield return current.Value;
                current = current.Next;
            } while (current != tail.Next);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
