using System;
using System.ComponentModel;

namespace DoublyLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList<int> list = new LinkedList<int>();

            list.AddFirst(1);
            list.AddFirst(3);
            list.AddLast(2);
            list.AddAfter(2, 5);
            list.AddAfter(2, 6);
            list.AddBefore(5, 4);

            list.PrintListForward();
            Console.WriteLine("----------------------");
            list.PrintListBackward();
            //list.RemoveFirst();
            //for (int i = 0; i < list.Count; i++)
            //{
            //    Console.WriteLine(list.ValueAt(i));
            //}
        }
    }
}
