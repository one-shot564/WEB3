using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_
{
    internal class Node<T>
    {
        public T Value { get; private set; }
        public Node<T> Next { get; set; }

        public Node(T value)
        {
            Value = value;
            Next = null; // При создании нового узла, следующий узел по умолчанию будет null
        }
    }
}
