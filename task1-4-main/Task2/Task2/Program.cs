using System;
using System.IO;

namespace Task2
{

    class Program
    {
        static void Main()
        {
            string path = Console.ReadLine();
            string path2 = Console.ReadLine();

            string[] File1 = File.ReadAllText(path).Replace("\r\n", " ").Split(" ");
            var mas1 = new float[File1.Length];
            for (int i = 0; i < File1.Length; i++)
            {
                mas1[i] = Convert.ToInt32(File1[i]);
            }

            string[] File2 = File.ReadAllText(path2).Replace("\r\n", " ").Split(" ");
            var mas2 = new float[File2.Length];
            for (int i = 0; i < File2.Length; i++)
            {
                mas2[i] = Convert.ToInt32(File2[i]);
            }

            for (int i = 0; i < mas2.Length; i += 2)
            {
                var FirstArgument = (int)Math.Pow(mas2[i] - mas1[0], 2);
                var SecondArgument = (int)Math.Pow(mas2[i + 1] - mas1[1], 2);
                var RadiusSquared = (int)Math.Pow(mas1[2], 2);
                if (FirstArgument + SecondArgument < RadiusSquared)
                {
                    Console.WriteLine(1);
                }
                else
                {
                    if (FirstArgument + SecondArgument == RadiusSquared)
                    {
                        Console.WriteLine(0);
                    }
                    else
                    {
                        Console.WriteLine(2);
                    }
                }
            }
        }
    }
}
