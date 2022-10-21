/*
*  Create a Task and attach continuations to it according to the following criteria:
   a.    Continuation task should be executed regardless of the result of the parent task.
   b.    Continuation task should be executed when the parent task finished without success.
   c.    Continuation task should be executed when the parent task would be finished with fail and parent task thread should be reused for continuation
   d.    Continuation task should be executed outside of the thread pool when the parent task would be cancelled
   Demonstrate the work of the each case with console utility.
*/
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace MultiThreading.Task6.Continuation
{
    class Program
    {
        static CancellationTokenSource tokenSource = new CancellationTokenSource();
        static CancellationToken token = tokenSource.Token;

        static void Main(string[] args)
        {
            Console.WriteLine("Create a Task and attach continuations to it according to the following criteria:");
            Console.WriteLine("a.    Continuation task should be executed regardless of the result of the parent task.");
            Console.WriteLine("b.    Continuation task should be executed when the parent task finished without success.");
            Console.WriteLine("c.    Continuation task should be executed when the parent task would be finished with fail and parent task thread should be reused for continuation.");
            Console.WriteLine("d.    Continuation task should be executed outside of the thread pool when the parent task would be cancelled.");
            Console.WriteLine("Demonstrate the work of the each case with console utility.");
            Console.WriteLine();

            var tokenSource2 = new CancellationTokenSource();
            CancellationToken ct = tokenSource2.Token;
            Task task = Task.Factory.StartNew(parentTask, token);
          

            task.ContinueWith((t1) =>
            {
                
                Console.WriteLine("Parent Task not Complete and any fault during operation");
                
       
            },TaskContinuationOptions.OnlyOnFaulted);
            task.ContinueWith((t1) =>
            {
                if (ct.IsCancellationRequested)
                {
                    Console.WriteLine("Parent Task is cancelled during the operation");

                }
                else
                {
                    Console.WriteLine("Next task running with impact of parent result");
                }

            }, TaskContinuationOptions.OnlyOnCanceled | TaskContinuationOptions.LongRunning);
            task.ContinueWith((t1) =>
            {
                if (task.IsCompletedSuccessfully)
                {
                    Console.WriteLine("Parent Task sucessfully Completed");
                }

            }, TaskContinuationOptions.OnlyOnRanToCompletion);
            
            Console.ReadLine();
          
        }

        static void parentTask()
        {

            Console.WriteLine("Parent Task Initialize");
        }
    }
}
