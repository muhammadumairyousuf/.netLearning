/*
 * 2.	Write a program, which creates a chain of four Tasks.
 * First Task – creates an array of 10 random integer.
 * Second Task – multiplies this array with another random integer.
 * Third Task – sorts this array by ascending.
 * Fourth Task – calculates the average value. All this tasks should print the values to console.
 */
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MultiThreading.Task2.Chaining
{
    class Program
    {
        static  void Main(string[] args)
        {
            Console.WriteLine(".Net Mentoring Program. MultiThreading V1 ");
            Console.WriteLine("2.	Write a program, which creates a chain of four Tasks.");
            Console.WriteLine("First Task – creates an array of 10 random integer.");
            Console.WriteLine("Second Task – multiplies this array with another random integer.");
            Console.WriteLine("Third Task – sorts this array by ascending.");
            Console.WriteLine("Fourth Task – calculates the average value. All this tasks should print the values to console");
            Console.WriteLine();

            // feel free to add your code
            Console.WriteLine("Create Random Numbers Array");
            Task task1 = Task.Factory.StartNew<int[]>(() => RandomInteger())
                .ContinueWith<int[]>((t1) => MultipleRandomInteger(t1.Result))
                .ContinueWith<int[]>((t2) => AscendingOrder(t2.Result))
                .ContinueWith((t3) => {
                    Console.WriteLine("Find Average");
                    int average = t3.Result.Sum() / 10;
                    Console.WriteLine("Average: " + average);
                }); 
            Console.ReadLine();  
        }

        static int[] RandomInteger()
        {

            Console.WriteLine("Multiply Random Array With Random Number");
            int[] randomNumbers = new int[10] ;
            Random random = new Random();
            for (int i=0;i<10;i++)
            {
                randomNumbers[i] = random.Next(1,20);
                Console.WriteLine(randomNumbers[i]);
            }
            return randomNumbers;
        }
        static int[] MultipleRandomInteger(int[] randomNumbers)
        {

            Random random = new Random();
            for (int i = 0; i < randomNumbers.Length; i++)
            {
                var number= random.Next(1,20);
                Console.WriteLine("Random Number: " + number);

                randomNumbers[i] = randomNumbers[i] * number;
                Console.WriteLine("Random Number after Multiply: " + randomNumbers[i]);

            }
            return randomNumbers;
        }
        static int[] AscendingOrder(int[] randomNumbers)
        {
            Console.WriteLine("Array in Ascending Order");
            var result = randomNumbers.ToList().OrderBy(x => x).ToArray();
            for (int i = 0; i < result.Length; i++)
            {
                Console.WriteLine(result[i]);

            }
            return result;
        }
    }
}
