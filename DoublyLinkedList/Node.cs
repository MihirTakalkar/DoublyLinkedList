﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DoublyLinkedList
{
    class Node<T>
    {
        public Node<T> Next { get; set; }
        public Node<T> Previous { get; set; }
        public T Value { get; set; }

        public Node(T Value)
        {
            this.Value = Value;
            Next = null;
            Previous = null;
        }
    }
}
