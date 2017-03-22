using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1Logic;

namespace Task1Console
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 4, 5, 3, 7, 1, 8, 123, 666, 20, 15, 3, 777, 100 };

            Console.WriteLine("Array before sort:");
            foreach (var i in arr)
            {
                Console.Write($"{i}{(i == (arr.Length - 1) ? "" : " ") } ");
            }

            Algorithm.MergeSort(arr);

            Console.WriteLine();
            Console.WriteLine("Array after sort:");
            foreach(var i in arr)
            {
                Console.Write($"{i}{(i == (arr.Length - 1) ? "" : " ") } ");
            }
        }
    }
}
