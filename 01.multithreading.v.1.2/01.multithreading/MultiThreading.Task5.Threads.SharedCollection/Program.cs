/*
 * 5. Write a program which creates two threads and a shared collection:
 * the first one should add 10 elements into the collection and the second should print all elements
 * in the collection after each adding.
 * Use Thread, ThreadPool or Task classes for thread creation and any kind of synchronization constructions.
 */
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;

namespace MultiThreading.Task5.Threads.SharedCollection
{
    class Program
    {
        static AutoResetEvent autoResetEvent=new AutoResetEvent(false);
        static List<int> collection = new List<int>();
        
        static void Main(string[] args)
        {
            Console.WriteLine("5. Write a program which creates two threads and a shared collection:");
            Console.WriteLine("the first one should add 10 elements into the collection and the second should print all elements in the collection after each adding.");
            Console.WriteLine("Use Thread, ThreadPool or Task classes for thread creation and any kind of synchronization constructions.");
            Console.WriteLine();

            // feel free to add your code

            Thread thread1 = new Thread(addElements);
            thread1.Start();
            autoResetEvent.WaitOne();
            Thread thread2 = new Thread(printElements);
            thread2.Start();
            Console.ReadLine();
        }

        public static void printElements(object obj)
        {
            for (int i = 0; i < collection.Count; i++)
            {
             
                Console.WriteLine(collection[i]);

            }


        }

        public static void addElements(object obj)
        {
            for (int i = 0; i < 10; i++)
            {
                collection.Add(i);
            }
           autoResetEvent.Set();
        }
    }
}
