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

        void AddFirst(T value)
        {
            var currentNode = Head;
            if(Head == null)
            {
                Head = new Node<T>(value);
                Tail = Head;
                Count++; 
            }

            else
            {
                currentNode = new Node<T>(value);
                currentNode.Next = Head;
                currentNode.Previous = Head;
                Head = currentNode;
                currentNode.Next.Previous = currentNode;
                Count++;
            }
        }

        void AddLast(T value)
        {
            if(Head == null)
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

        void AddBefore(Node<T> node, T value)
        {
            if(Head == null || Head == node)
            {
                AddFirst(value);
            }

            else
            {
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

        void AddAfter(Node <T> node, T value)
        {
            if(Head == null)
            {
                AddFirst(value);
            }

            else if(Tail == node)
            {
                AddLast(value);
            }

            else
            {
                var currentNode = Head;
                while(currentNode != null)
                {
                    currentNode = currentNode.Next;
                }
                var temp = currentNode.Next;
                currentNode.Next = new Node<T>(value);
                currentNode.Next.Previous = currentNode;
                currentNode.Next.Next = temp;
                temp.Previous = currentNode.Next;
                Count++;
            }

        }

        bool RemoveFirst()
        {
            if(Head == null)
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

        bool RemoveLast()
        {
            if(Head == null)
            {
                return false;
            }

            else
            {
                Tail = Tail.Previous;
                Tail.Next = null;
            }\
            return true;
        }

        bool Remove(T value)
        {

        }

        bool IsEmpty()
        {

        }



    }
}
