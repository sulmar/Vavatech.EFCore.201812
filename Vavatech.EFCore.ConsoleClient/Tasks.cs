using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Vavatech.EFCore.ConsoleClient
{
    class Tasks
    {
        public static void Test()
        {
            DisplayThreadId();

            //Task task = Task.Run(()=>DoWork());

            //task.Wait();

            Task.Run(() => DoWork());

            //Task.Run(() => Calculate())
            //    .ContinueWith(t => Console.WriteLine($"Result = {t.Result}"));

            CalculateAsyncTest();

            CalculateParallelTest();

        }

        //private static void CalculateAsyncTest()
        //{
        //    CalculateAsync()
        //        .ContinueWith(t => Console.WriteLine($"Result = {t.Result}"));
        //}


        private static void CalculateParallelTest()
        {
            Task<decimal> task1 = CalculateAsync();

            Task<decimal> task2 = CalculateAsync();

            Task.WaitAll(task1, task2);

            decimal result = task1.Result + task2.Result;

            Console.WriteLine($"Result = {result}");
        }

        private static async void CalculateAsyncTest()
        {
            decimal result1 = await CalculateAsync();

            decimal result2 = await CalculateAsync();

            decimal result = result1 + result2;

            Console.WriteLine($"Result = {result}");
        }

        private static void DisplayThreadId()
        {
            Console.WriteLine($"#{Thread.CurrentThread.ManagedThreadId}");
        }

        private static Task<decimal> CalculateAsync()
        {
            return Task.Run(() => Calculate());
        }


        private static decimal Calculate()
        {
            Console.WriteLine("Calculating...");
            DisplayThreadId();

            Thread.Sleep(TimeSpan.FromSeconds(5));

            Console.WriteLine("Calcuted.");
            DisplayThreadId();

            return 100;
        }

        private static void DoWork()
        {
            Console.WriteLine("Sending...");
            DisplayThreadId();

            Thread.Sleep(TimeSpan.FromSeconds(5));

            Console.WriteLine("Sent.");
            DisplayThreadId();
        }
    }
}
