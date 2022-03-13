using System;
using System.Collections.Generic;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            int k = Convert.ToInt32(Console.ReadLine());
            int s = Convert.ToInt32(Console.ReadLine());
            int[] arrayLength = new int[k];
            List<int> receivedPath = new List<int>();

            for (int i = 0; i < k; i++)
            {
                arrayLength[i] = i + 1;
            }
            receivedPath.Add(arrayLength[0]);

            for (int i = s - 1; ; i += s - 1)
            {
                while (i >= k)
                {
                    i -= k;
                }
                if (receivedPath.Contains(arrayLength[i]))
                {
                    break;
                }
                receivedPath.Add(arrayLength[i]);
            }
            foreach (var part in receivedPath)
            {
                Console.WriteLine(part);
            }
        }
    }
}
