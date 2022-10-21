/*
 * 4.	Write a program which recursively creates 10 threads.
 * Each thread should be with the same body and receive a state with integer number, decrement it,
 * print and pass as a state into the newly created thread.
 * Use Thread class for this task and Join for waiting threads.
 * 
 * Implement all of the following options:
 * - a) Use Thread class for this task and Join for waiting threads.
 * - b) ThreadPool class for this task and Semaphore for waiting threads.
 */

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace MultiThreading.Task4.Threads.Join
{
    class Program
    {
       static SemaphoreSlim semaphoreSlim = new SemaphoreSlim(10);

        static void Main(string[] args)
        {
            Console.WriteLine("4.	Write a program which recursively creates 10 threads.");
            Console.WriteLine("Each thread should be with the same body and receive a state with integer number, decrement it, print and pass as a state into the newly created thread.");
            Console.WriteLine("Implement all of the following options:");
            Console.WriteLine();
            Console.WriteLine("- a) Use Thread class for this task and Join for waiting threads.");
            Console.WriteLine("- b) ThreadPool class for this task and Semaphore for waiting threads.");

            Console.WriteLine();


            // feel free to add your code
            int numThreads = 10;
          //  WaitCallback waitCallback = new WaitCallback(EnterSempahore);
           // ThreadPool.QueueUserWorkItem(waitCallback, numThreads);
            Task task = Task.Factory.StartNew(()=>printThread(numThreads));
           
            Console.ReadLine();
        }

        private static void printThread(int numThreads)
        {
            if (numThreads > 0)
            {
                Console.WriteLine("New Thread" + numThreads);
                
                Thread t= new Thread(()=>printThread(numThreads - 1));
                t.Start();
                t.Join();
            }
        }

        //private static void EnterSempahore(object i)
        //{
        //    int x = Convert.ToInt32(i);
        //    while(x>0)
        //    {
        //        Thread t1 = new Thread(threadProc);
        //        t1.Start(x);
        //        t1.Join();
        //        x--;
        //    }

        //    semaphoreSlim.Wait();
        //}


        //private static void threadProc(object state)
        //{
        //    Console.WriteLine("New Thread" + state.ToString());
        //}





    }


}
