using System;
using System.IO;
using System.Linq;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = Console.ReadLine();
            int count = 0;

            string[] File1 = File.ReadAllText(path).Replace("\r\n", " ").Split(" ");
            var nums = new int[File1.Length];
            for (int i = 0; i < File1.Length; i++)
            {
                nums[i] = Convert.ToInt32(File1[i]);
            }

            int average = nums.Sum() / nums.Count();

            for (int i = 0; i < nums.Count(); i++)
            {
                while (nums[i] < average)
                {
                    nums[i]++;
                    count++;
                }
                while (nums[i] > average)
                {
                    nums[i]--;
                    count++;
                }
            }

            Console.WriteLine(count);
        }
    }
}
