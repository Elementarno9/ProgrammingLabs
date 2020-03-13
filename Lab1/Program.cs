using System;

namespace Lab1
{
    // Variant 4
    // By Akhmetgaliev Eduard
    class Program
    {
        // Test values:
        // 0    ->  0
        // 1    ->  -0.105155115125...
        // 2.5  ->  13.0899959013...
        static void Main()
        {
            double value = ReadDouble("Введите число: ");
            double result = ComputeFunction(value);
            Console.WriteLine("F({0}) = {1}", value, result);
        }

        static double ReadDouble(string inputText)
        {
            bool flag = false;
            double result;
            do {
                Console.Write(inputText);
                string line = Console.ReadLine();
                if (double.TryParse(line, out result)) flag = true;
                else Console.WriteLine("Ошибка: нужно ввести число.");
            } while (!flag);

            return result;
        }

        static double ComputeFunction(double a)
        {
            double a1 = Math.Sin(2 * a) + Math.Sin(5 * a) - Math.Sin(3 * a);
            double a2 = Math.Cos(a) - Math.Cos(3 * a) + Math.Cos(5 * a);
            return a1 / a2;
        }
    }
}
