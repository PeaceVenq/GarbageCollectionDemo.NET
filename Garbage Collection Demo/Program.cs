using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Garbage_Collection_Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CheckMemoryWithCollections();
            TriggerCollectionByGenerations();
            ////TriggerCollectionByGeneration(0);
            PrintMemoryUsage("Memory After Calling GC Collect \n\n");

            CheckMemoryWithManaged();
            Console.WriteLine("\n \n");
            CheckMemoryWithUnmanaged();
            Console.Read();

        }

    

        private static void CheckMemoryWithCollections()
        {
            int[] numCollection = new int[24000];
            PrintMemoryUsage("Intialized an integer collection");
            Task.Delay(2000).Wait();
            long[] numCollection2 = new long[24000];
            //List<long> numCollection3 = new List<long>();
            PrintMemoryUsage("Intialized an long collection");
            #region Assigning values to collection
            for (int i = 0; i < numCollection.Length; i++)
            {
                numCollection[i] = i * i;
            }
            PrintMemoryUsage("After Allocating a element to int collection");

            for (long i = 0; i < numCollection2.Length; i++)
            {
                numCollection2[i] = i * i;
            }
            PrintMemoryUsage("After allocating a element into long collection");

            //for (long i = 0; i < 24000; i++)
            //{
            //    numCollection3.Add(i * i);
            //}
            //PrintMemoryUsage("After allocating a element into long collection");
            #endregion


            Task.Delay(2000).Wait();

        }

        private static void CheckMemoryWithManaged()
        {
            var objectsCollection = new List<Car>();
            PrintMemoryUsage("Usage after creating empty object collection");
            for (int i = 0; i < 10; i++)
            {
                var car = new Car($"car {i}", $"Self Driving Car {1}");
                objectsCollection.Add(car);
            }
            PrintMemoryUsage("Usage after adding elements to object collection");
            PrintResourceGeneration("Check Generation for Object Collection", objectsCollection);
            TriggerCollectionByGeneration(0);
            PrintResourceGeneration("Check Generation for Object Collection", objectsCollection);
            objectsCollection = null;
            TriggerCollectionByGeneration(1);

        }

        private static void CheckMemoryWithUnmanaged()
        {
            var objectsCollection = new List<DisposableCar>();
            PrintMemoryUsage("Usage after creating empty object collection");
            for (int i = 0; i < 10; i++)
            {
                var car = new DisposableCar($"car {i}", $"Self Driving Car {1}");
                objectsCollection.Add(car);
            }
            PrintMemoryUsage("Usage after adding elements to object collection");
            PrintResourceGeneration("Check Generation for Object Collection", objectsCollection);
            TriggerCollectionByGeneration(0);
            PrintResourceGeneration("Check Generation for Object Collection", objectsCollection);

            //Failing GC 1
            //objectsCollection = null;
            //TriggerCollectionByGeneration(1);

            //Passing GC 1
            foreach (var car in objectsCollection)
            {
                car.Dispose();
            }
            TriggerCollectionByGeneration(1);
        }


        private static void PrintMemoryUsage(string message)
        {
            Console.WriteLine(new string('#', 20));
            Console.WriteLine(message);
            Console.WriteLine(GC.GetTotalMemory(false));
        }

        private static void PrintResourceGeneration(string message, object objectToCheck)
        {
            Console.WriteLine(new string('*', 20));
            Console.WriteLine(message);
            Console.WriteLine(GC.GetGeneration(objectToCheck));
        }

        private static void TriggerCollectionByGenerations()
        {
            PrintMemoryUsage("Memory Before Calling GC Collect 0");
            GC.Collect(0);
            Console.WriteLine(GC.CollectionCount(0));
            PrintMemoryUsage("Memory Before Calling GC Collect 1");
            GC.Collect(1);
            Console.WriteLine(GC.CollectionCount(1));
            PrintMemoryUsage("Memory Before Calling GC Collect 2");
            GC.Collect(2);
            Console.WriteLine(GC.CollectionCount(2));
        }

        private static void TriggerCollectionByGeneration(int gcGeneration)
        {
            PrintMemoryUsage($"Memory Before Calling GC Collect {gcGeneration}");
            GC.Collect(gcGeneration);
            PrintMemoryUsage($"Memory After Calling GC Collect {gcGeneration}");
        }
    }
}


//https://learn.microsoft.com/en-us/dotnet/standard/garbage-collection/fundamentals


