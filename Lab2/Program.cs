using System;

namespace Lab2
{
    // Variant 4
    // By Akhmetgaliev Eduard
    class Program
    {
        const double FunctionStart = -10;
        const double FunctionEnd = 6;

        static void Main(string[] args)
        {
            // TODO: part 2.2, 3.1, 3.2
            // Choosing part
            PieceFunction();
        }

        static void PieceFunction()
        {
            double value = ReadDouble("Введите число: ");
            double result;
            if (ComputeFunction(value, out result)) Console.WriteLine("F({0}) = {1}", value, result);
            else Console.WriteLine("Ошибка: аргумент за пределами области определения [{0};{1}]", FunctionStart, FunctionEnd);
        }

        static double ReadDouble(string inputText)
        {
            bool flag = false;
            double result;
            do
            {
                Console.Write(inputText);
                string line = Console.ReadLine();
                if (double.TryParse(line, out result)) flag = true;
                else Console.WriteLine("Ошибка: нужно ввести число.");
            } while (!flag);

            return result;
        }

        static bool ComputeFunction(double value, out double result)
        {
            if (value < FunctionStart || value > FunctionEnd)
            {
                result = 0;
                return false;
            }

            if (value <= 0) result = -value / 2 - 3;
            else if (value <= 3) result = -Math.Sqrt(9 - Math.Pow(value, 2));
            else result = Math.Sqrt(9 - Math.Pow(value - 6, 2));

            return true;
        }
    }
}
