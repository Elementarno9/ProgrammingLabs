using System;

namespace Lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            ComputeFloats(ReadFloatsFromConsole());
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

        static double[] ReadFloatsFromConsole()
        {
            Console.Write("Введите размер массива: ");
            int n = int.Parse(Console.ReadLine());

            var arr = new double[n];
            for (int i = 0; i < n; i++)
            {
                arr[i] = ReadDouble($"[{i+1}] Введите число: ");
            }

            return arr;
        }

        static void ComputeFloats(double[] arr)
        {
            double oddSum = 0, betweenNegSum = 0;
            int firstNegIdx = -1, lastNegIdx = -1;

            // Sum odd numbers & find first/last negative numbers
            for (int i = 0; i < arr.Length; i++)
            {
                if (i % 2 == 0) oddSum += arr[i];

                if (arr[i] < 0)
                {
                    firstNegIdx = firstNegIdx == -1 ? i : firstNegIdx;
                    lastNegIdx = i;
                }
            }
            
            // Sum between first and last negative numbers
            if (lastNegIdx > firstNegIdx)
            {
                for (int i = firstNegIdx + 1; i < lastNegIdx; i++) { betweenNegSum += arr[i]; Console.WriteLine(i); }
            }

            // Transform array


            Console.WriteLine("Сумма нечетных элементов: {0}\nСумма между первым и последним отрицательным элементом: {1}", oddSum, betweenNegSum);
        }
    }
}
