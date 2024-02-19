using System;
using System.IO;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WritingToFile
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Task 1");
            Program.task1();

            Console.WriteLine("Task 2");
            Program.task2();
        }

        public static void task2()
        {
            File.AppendAllText("C#23.txt", "");
            using (var stream3 = new StreamReader("C#23.txt"))
            {
                string eilute = stream3.ReadLine();
                SplitString(eilute);
                char delimiter = ' ';
                int quantityOfWords = eilute.Split(delimiter, StringSplitOptions.RemoveEmptyEntries).Length; ;
                Console.WriteLine($"File contains {quantityOfWords} words");
            }
        }

        public static void task1()
        {
            using (var stream2 = new StreamReader("C#22.txt"))
            {
                string eilute = stream2.ReadLine();
                string[] naujaEilute = SplitString(eilute);
                List<int> numbers = ConvertStrigIntoInt(naujaEilute);
                int maxNumber = MaxNumber(numbers);
                Console.WriteLine($"Max number is {maxNumber}");
                int minNumber = MinNumber(numbers);
                Console.WriteLine($"Min number is {minNumber}");
                double average = AverageOfNumbers(numbers);
                Console.WriteLine($"Average is {average}");
                int randomNumber = RandomNuberFromList(numbers);
                Console.WriteLine($"Random number {randomNumber}");
                Console.WriteLine();
            }
        }
        public static void crud()
        {
            File.AppendAllText("C#22.txt", " labas" + "\n");

            List<string> lines = new();
            using (StreamReader sr2 = new StreamReader("C#22.txt"))
            {
                string line;
                while ((line = sr2.ReadLine()) != null)
                {
                    lines.Add(line);
                }
            }

            foreach (var item in lines)
            {
                Console.WriteLine(item);
            }

            using (StreamReader reader = new StreamReader("C#22.txt"))
            using (StreamWriter writer = new StreamWriter("C#22.tmp"))
            {
                string valToEdit = "labas";
                string newValue = "";
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (line.Contains(valToEdit))
                    {
                        writer.WriteLine(newValue);
                    }
                    else
                    {
                        writer.WriteLine(line);
                    }
                }
                reader.Close();
            }

            File.Replace("C#22.tmp", "C#22.txt", null);

            using (StreamReader reader = new StreamReader("C#22.txt"))
            using (StreamWriter writer = new StreamWriter("C#22.tmp"))
            {
                string valToDelete = "labas";
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (!line.Contains(valToDelete))
                    {
                        writer.WriteLine(line);
                    }
                }
                reader.Close();
            }
            File.Replace("C#22.tmp", "C#22.txt", null);
        }


        public static string[] SplitString(string s)
        {
            return s.Split(' ');
        }

        public static List<int> ConvertStrigIntoInt(string[] s)
        {
            return s.Select(int.Parse).ToList();
        }

        public static int MaxNumber(List<int> numbers)
        {
            {
                return numbers.Max();
            }
        }
        public static int MinNumber(List<int> numbers)
        {
            {
                return numbers.Min();
            }
        }
        public static double AverageOfNumbers(List<int> numbers)
        {
            {
                return numbers.Average();
            }
        }
        public static int RandomNuberFromList(List<int> numbers)
        {
            Random random = new Random();
            int randomIndex = random.Next(0, numbers.Count);
            int rnd = numbers[randomIndex];
            return rnd;
        }
    }
}



