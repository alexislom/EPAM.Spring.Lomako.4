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

            queue.Enqueue(7);
            queue.Enqueue(8);
            queue.Enqueue(9);
            queue.Enqueue(555);
            queue.Enqueue(666);

            Console.WriteLine("\nMy queue:");
            foreach (int i in queue)
                Console.Write(i + " ");

            Console.WriteLine("\n\nPeek element: " + queue.Peek());
            queue.Dequeue();
            Console.WriteLine("\nPeek element after deque: " + queue.Peek());

            queue.Dequeue();
            queue.Dequeue();
            queue.Dequeue();

            Console.WriteLine("\nMy queue:");
            foreach (int i in queue)
                Console.Write(i + " ");

            Queue<string> queueTwo = new Queue<string>(5);
            queueTwo.Enqueue("string1");
            queueTwo.Enqueue("string2");
            queueTwo.Enqueue("string3");
            queueTwo.Enqueue("string4");
            queueTwo.Enqueue("string5");

            Console.WriteLine("\n\nMy second queue:");
            foreach (var i in queueTwo)
                Console.Write(i + " ");

            Console.WriteLine();

        }
    }
}
