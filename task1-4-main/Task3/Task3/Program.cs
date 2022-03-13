using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileName = Console.ReadLine();
            string jsonString1 = File.ReadAllText(fileName);
            string fileName2 = Console.ReadLine();
            string jsonString2 = File.ReadAllText(fileName2);

            FirstFileData File1 = JsonSerializer.Deserialize<FirstFileData>(jsonString1)!;
            SecondFileData File2 = JsonSerializer.Deserialize<SecondFileData>(jsonString2)!;

            foreach (var secondFileValue in File2.values)
            {
                var coincidence = File1.tests.SingleOrDefault(p => p.id == secondFileValue.id);
                if (coincidence == null)
                {
                    foreach (var firstFileValue in File1.tests)
                    {
                        if (firstFileValue.values != null)
                        {
                            var coincidence2 = firstFileValue.values.SingleOrDefault(p => p.id == secondFileValue.id);
                            if (coincidence2 != null)
                            {
                                coincidence2.value = secondFileValue.value;
                                break;
                            }
                            else
                            {
                                SearchCoincidences(secondFileValue, firstFileValue.values);
                            }
                        }
                    }
                }
                else
                {
                    coincidence.value = secondFileValue.value;
                }
            }
            string jsonString3 = JsonSerializer.Serialize(File1);
            File.WriteAllText("report.json", jsonString3);
        }
        public static void SearchCoincidences(Value2 secondFileValue, List<Value1> firstFileValue)
        {
            foreach (var c in firstFileValue)
            {
                if (firstFileValue != null)
                {
                    var coincidence = firstFileValue.SingleOrDefault(c => c.id == secondFileValue.id);
                    if (coincidence != null)
                    {
                        coincidence.value = secondFileValue.value;
                        break;
                    }
                    if (c.values != null)
                    {
                        SearchCoincidences(secondFileValue, c.values);
                    }
                }
            }
        }
    }
    public class Value1
    {
        public int id { get; set; }
        public string title { get; set; }
        public string value { get; set; }
        public List<Value1> values { get; set; }
    }

    public class FirstFileData
    {
        public List<Value1> tests { get; set; }
    }
    public class Value2
    {
        public int id { get; set; }
        public string value { get; set; }
    }

    public class SecondFileData
    {
        public List<Value2> values { get; set; }
    }

}
