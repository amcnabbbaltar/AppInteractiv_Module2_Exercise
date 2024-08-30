using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

class Program
{
    static void Main()
    {
        // Test parameters
        int[] sizes = { 125000, 250000, 500000 };
        int[] accessSizes = { 12500, 25000, 50000 };

        foreach (int size in sizes)
        {
            Console.WriteLine($"Testing with {size} elements");

            // List with array (List<int> in C#)
            List<int> arrayList = new List<int>();
            LinkedList<int> linkedList = new LinkedList<int>();

            // Insertions at the end
            Console.WriteLine("Insertions at the end:");
            Console.WriteLine($"Array List: {MeasureInsertionEnd(arrayList, size)} ms");
            Console.WriteLine($"Linked List: {MeasureInsertionEnd(linkedList, size)} ms");

            // Insertions at the beginning
            arrayList.Clear();
            linkedList.Clear();

            Console.WriteLine("Insertions at the beginning:");
            Console.WriteLine($"Array List: {MeasureInsertionStart(arrayList, size)} ms");
            Console.WriteLine($"Linked List: {MeasureInsertionStart(linkedList, size)} ms");

            // Access elements randomly
            int[] randomIndices = GenerateRandomIndices(size, 50000);

            Console.WriteLine("Access random elements:");
            Console.WriteLine($"Array List (12,500 accesses): {MeasureAccess(arrayList, randomIndices, accessSizes[0])} ms");
            Console.WriteLine($"Linked List (12,500 accesses): {MeasureAccess(linkedList, randomIndices, accessSizes[0])} ms");
            Console.WriteLine($"Array List (25,000 accesses): {MeasureAccess(arrayList, randomIndices, accessSizes[1])} ms");
            Console.WriteLine($"Linked List (25,000 accesses): {MeasureAccess(linkedList, randomIndices, accessSizes[1])} ms");
            Console.WriteLine($"Array List (50,000 accesses): {MeasureAccess(arrayList, randomIndices, accessSizes[2])} ms");
            Console.WriteLine($"Linked List (50,000 accesses): {MeasureAccess(linkedList, randomIndices, accessSizes[2])} ms");

            // Deletion of elements
            Console.WriteLine("Deletion of random elements:");
            Console.WriteLine($"Array List: {MeasureDeletion(arrayList, randomIndices)} ms");
            Console.WriteLine($"Linked List: {MeasureDeletion(linkedList, randomIndices)} ms");

            Console.WriteLine();
        }
    }

    // Measure the time taken to insert elements at the end
    static long MeasureInsertionEnd(ICollection<int> collection, int size)
    {
        Stopwatch stopwatch = Stopwatch.StartNew();
        for (int i = 0; i < size; i++)
        {
            collection.Add(i);
        }
        stopwatch.Stop();
        return stopwatch.ElapsedMilliseconds;
    }

    // Measure the time taken to insert elements at the beginning
    static long MeasureInsertionStart(List<int> list, int size)
    {
        Stopwatch stopwatch = Stopwatch.StartNew();
        for (int i = 0; i < size; i++)
        {
            list.Insert(0, i);
        }
        stopwatch.Stop();
        return stopwatch.ElapsedMilliseconds;
    }

    static long MeasureInsertionStart(LinkedList<int> linkedList, int size)
    {
        Stopwatch stopwatch = Stopwatch.StartNew();
        for (int i = 0; i < size; i++)
        {
            linkedList.AddFirst(i);
        }
        stopwatch.Stop();
        return stopwatch.ElapsedMilliseconds;
    }

    // Measure the time taken to access random elements
    static long MeasureAccess(IList<int> list, int[] randomIndices, int accessSize)
    {
        Stopwatch stopwatch = Stopwatch.StartNew();
        for (int i = 0; i < accessSize; i++)
        {
            int temp = list[randomIndices[i]];
        }
        stopwatch.Stop();
        return stopwatch.ElapsedMilliseconds;
    }

    static long MeasureAccess(LinkedList<int> linkedList, int[] randomIndices, int accessSize)
    {
        Stopwatch stopwatch = Stopwatch.StartNew();
        foreach (int index in randomIndices.Take(accessSize))
        {
            linkedList.Find(index);
        }
        stopwatch.Stop();
        return stopwatch.ElapsedMilliseconds;
    }

    // Measure the time taken to delete elements from a List<int>
    static long MeasureDeletion(List<int> list, int[] randomIndices)
    {
        Stopwatch stopwatch = Stopwatch.StartNew();
        // Start from the highest index to avoid shifting issues
        foreach (int index in randomIndices.OrderByDescending(i => i))
        {
            list.RemoveAt(index);
        }
        stopwatch.Stop();
        return stopwatch.ElapsedMilliseconds;
    }

    // Measure the time taken to delete elements from a LinkedList<int>
    static long MeasureDeletion(LinkedList<int> linkedList, int[] randomIndices)
    {
        Stopwatch stopwatch = Stopwatch.StartNew();
        foreach (int index in randomIndices)
        {
            var node = linkedList.First;
            linkedList.Remove(node);
        }
        stopwatch.Stop();
        return stopwatch.ElapsedMilliseconds;
    }

    // Generate random indices
    static int[] GenerateRandomIndices(int maxValue, int count)
    {
        Random rand = new Random();
        int[] indices = new int[count];
        for (int i = 0; i < count; i++)
        {
            indices[i] = rand.Next(0, maxValue);
        }
        return indices;
    }
}
