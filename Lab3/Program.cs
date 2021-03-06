﻿using System;

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

        /*
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
        }*/

        static double[] ReadFloatsFromConsole()
        {
            Console.Write("Введите массив: ");
            string[] nums = Console.ReadLine().Split();

            var arr = new double[nums.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                double.TryParse(nums[i], out arr[i]);
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
                for (int i = firstNegIdx + 1; i < lastNegIdx; i++) betweenNegSum += arr[i];
            }

            // Transform array
            double[] resultArr = new double[arr.Length];
            for (int i = 0, j = 0; i < arr.Length; i++)
            {
                if (arr[i] <= 1)
                {
                    resultArr[j] = arr[i];
                    j++;
                }
            }


            Console.WriteLine("Сумма нечетных элементов: {0}\nСумма между первым и последним отрицательным элементом: {1}\nОбновленный массив: {2}", oddSum, betweenNegSum, string.Join(" ", resultArr));
        }
    }
}
