using System;

namespace lab_1
{
    internal class RingNode<T>
    {
        public T Value { get; private set; }
        public RingNode<T> Next { get; set; }

        public RingNode(T value)
        {
            Value = value;
            Next = null; // По умолчанию следующий элемент не определён
        }
    }
}
