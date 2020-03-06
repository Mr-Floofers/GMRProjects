using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoublyCircularlyLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {

            var list = new DoublyCircularlyLinkedList.LinkedList<int>();
            list.AddFirst(0);
            list.AddAfter(1, 0);
            list.AddAfter(2, 1);
            list.AddAfter(3, 2);

            Console.WriteLine(list.Head.value);
            Console.WriteLine(list.Head.next.value);
            Console.WriteLine(list.Head.next.next.value);
            Console.WriteLine(list.Tail.value);
            Console.WriteLine(list.Head.pre.value);

            Console.ReadKey();
        }
    }
}
