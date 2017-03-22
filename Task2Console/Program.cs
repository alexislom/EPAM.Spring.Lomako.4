using System;
using Task2Logic;

namespace Task2Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> queue = new Queue<int>(5);

            for (int i = 0; i < 5; i++)
                queue.Enqueue(i * 10);

            
            Console.WriteLine("My queue:");
            foreach (int i in queue)
                Console.Write(i+" ");

            queue.Enqueue(555);
            queue.Enqueue(666);

            Console.WriteLine("\n\nCyclicity(enque with full queue):");
            foreach (int i in queue)
                Console.Write(i + " ");

            queue.Dequeue();

            Console.WriteLine("\n\nMy queue after 1 deque:");
            foreach (int i in queue)
                Console.Write(i + " ");

            Console.WriteLine("\n\nPeek element: " + queue.Peek());

        }
    }
}
