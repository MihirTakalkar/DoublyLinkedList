using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;
using System.Transactions;

namespace DoublyLinkedList
{
    class LinkedList<T>
    {
        public int Count { get; private set; }

        Node<T> Head;
        Node<T> Tail;

        public void AddFirst(T value)
        {
            if (Head == null)
            {
                Head = new Node<T>(value);
                Tail = Head;
                Count++;
            }

            else
            {
                var newNode = new Node<T>(value);

                newNode.Next = Head;
                Head.Previous = newNode;

                Head = newNode;


                //var currentNode = new Node<T>(value);
                //currentNode.Next = Head;
                //currentNode.Previous = Head;
                //Head = currentNode;
                //currentNode.Next.Previous = currentNode;
                Count++;
            }
        }

        public void PrintListForward()
        {
            var current = Head;

            for (int i = 0; i < Count; i++, current = current.Next)
            {
                Console.WriteLine(current.Value);
            }
        }

        public void PrintListBackward()
        {
            var current = Tail;
            for (int i = 0; i < Count; i++, current = current.Previous)
            {
                Console.WriteLine(current.Value);
            }
        }

        public void AddLast(T value)
        {
            if (Head == null)
            {
                AddFirst(value);
            }

            else
            {
                Tail.Next = new Node<T>(value);
                Tail.Next.Previous = Tail;
                Tail = Tail.Next;
                Count++;
            }
        }

        public void AddBefore(T nodeVal, T value)
        {
            if (Head == null || Head.Value.Equals(nodeVal))
            {
                AddFirst(value);
            }

            else
            {
                var node = SearchNode(nodeVal);
                var currentNode = Head;
                while (currentNode != node)
                {
                    currentNode = currentNode.Next;

                    //Only if the value isn't found
                    if (currentNode == null)
                    {
                        return;
                    }

                }
                var temp = currentNode.Previous;
                currentNode.Previous = new Node<T>(value);
                currentNode.Previous.Next = currentNode;
                currentNode.Previous.Previous = temp;
                temp.Next = currentNode.Previous;
                Count++;
            }
        }

        public void AddAfter(T nodeVal, T value)
        {
            Node<T> node = SearchNode(nodeVal);
            
            if (Head == null || node == null)
            {
                AddFirst(value);
            }

            else if (Tail == node)
            {
                AddLast(value);
            }

            else
            {
                Node<T> nodeAfter = node.Next;

                Node<T> newNode = new Node<T>(value);

                newNode.Next = nodeAfter;
                nodeAfter.Previous = newNode;

                node.Next = newNode;
                newNode.Previous = node;

                //while (currentNode.Next != null)
                //{
                //    currentNode = currentNode.Next;
                //}
                //var temp = currentNode.Next;
                //currentNode.Next = new Node<T>(value);
                //currentNode.Next.Previous = currentNode;
                //currentNode.Next.Next = temp;
                //temp.Previous = currentNode.Next;
                Count++;
            }

        }

        public bool RemoveFirst()
        {
            if (Head == null)
            {
                return false;
            }

            else
            {
                Head = Head.Next;
                Head.Previous = null;
                Count--;
            }
            return true;
        }

        public bool RemoveLast()
        {
            if (Head == null)
            {
                return false;
            }

            else
            {
                Tail = Tail.Previous;
                Tail.Next = null;
                Count--;
            }
            return true;
        }

        public bool Remove(T value)
        {

            if (Head.Value.Equals(value))
            {
                RemoveFirst();
            }

            else if (Tail.Value.Equals(value))
            {
                RemoveLast();
            }

            var currentNode = Head;
            while (currentNode.Next != null)
            {
                if (currentNode.Value.Equals(value))
                {
                    currentNode.Next.Previous = currentNode.Previous;
                    currentNode.Previous.Next = currentNode.Next;
                    Count--;
                    return true;
                }

                else
                {
                    currentNode = currentNode.Next;
                }
            }
            return false;
        }

        public bool IsEmpty()
        {
            if (Head == null)
            {
                return true;
            }

            else
            {
                return false;
            }
        }

        public T ValueAt(int index)
        {
            if (index < 0 || index >= Count)
            {
                throw new IndexOutOfRangeException();
            }


            var currentNode = Head;

            for (int i = 0; i < index; i++)
            {
                currentNode = currentNode.Next;
            }
            return currentNode.Value;

        }

        public Node<T> SearchNode(T value)
        {
            var currentNode = Head;
            while (currentNode != null)
            {
                if (currentNode.Value.Equals(value))
                {
                    break;
                }

                currentNode = currentNode.Next;
            }
            return currentNode;
        }


    }
}
