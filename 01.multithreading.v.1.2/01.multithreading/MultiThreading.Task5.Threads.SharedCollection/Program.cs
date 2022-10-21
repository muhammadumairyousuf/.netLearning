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
using System.Threading.Tasks;

namespace MultiThreading.Task5.Threads.SharedCollection
{
    class Program
    {
        static EventWaitHandle first = new AutoResetEvent(false);
        static EventWaitHandle second = new AutoResetEvent(false);
        static List<int> collection = new List<int>();


        static void Main(string[] args)
        {
            Console.WriteLine("5. Write a program which creates two threads and a shared collection:");
            Console.WriteLine("the first one should add 10 elements into the collection and the second should print all elements in the collection after each adding.");
            Console.WriteLine("Use Thread, ThreadPool or Task classes for thread creation and any kind of synchronization constructions.");
            Console.WriteLine();

            Task task1 =  Task.Run(() => { 
            
            });
            Task task2 = Task.Run(() => {

            });

 //           Task task2 = Task.Factory.StartNew(printElements);
            // feel free to add your code
            for (int i = 0; i < 10; i++)
            {
                task1.ContinueWith((t1) => { addElements(i); });
                first.WaitOne();
                task2.ContinueWith((t1) => { printElements(); });


                second.WaitOne();

            }

            Console.ReadLine();
        }

        public static void printElements()
        {
            for (int j = 0; j < collection.Count; j++)
            {
                Console.WriteLine(collection[j]);

            }
            second.Set();
        }




        public static void addElements(int i)
        {
            collection.Add(i);
            Console.WriteLine("added:" + i);
            first.Set();

        }
    }
}
