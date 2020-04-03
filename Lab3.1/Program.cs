using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab3._1
{
    class Program
    {
        static void Main(string[] args)
        {
            var matrix = ReadMatrixFromConsole();
            PrintMatrix(matrix);
            ComputeFloats(matrix);
        }

        static double[][] ReadMatrixFromConsole()
        {
            Console.WriteLine("Ввод матрицы. (конец = пустая строка)");
            var rows = new List<double[]>();
            int maxLength = 0;
            while (true)
            {
                Console.Write("[{0}]: ", rows.Count + 1);
                string s = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(s)) break;
                string[] nums = s.Split();

                if (nums.Length > maxLength) maxLength = nums.Length;
                var arr = new double[nums.Length];
                for (int i = 0; i < arr.Length; i++)
                {
                    double.TryParse(nums[i], out arr[i]);
                }
                rows.Add(arr);

            }
            double[][] result = new double[rows.Count][];
            for (int i = 0; i < rows.Count; i++)
            {
                result[i] = new double[maxLength];
                for (int j = 0; j < rows[i].Length; j++) result[i][j] = rows[i][j];
            }
            return result;
        }

        static void ComputeFloats(double[][] matrix)
        {
            Console.WriteLine("Суммы по строкам с неотрицательными числами:");
            double sum = 0;
            for (int i = 0; i < matrix.Length; i++)
            {
                if (matrix[i].Min() >= 0)
                {
                    sum += matrix[i].Sum();
                    Console.WriteLine("[{0}] Sum = {1}", i + 1, matrix[i].Sum());
                }
            }
            Console.WriteLine("Итого: {0}", sum);

            double minSum = double.MaxValue;
            for (int i = 0; i < matrix[0].Length; i++)
            {
                var diags = new List<IEnumerable<double>>()
                {
                    GetDiagonal(matrix, i, 0),
                    GetDiagonal(matrix, 0, i),
                    GetDiagonal(matrix, i, 0, -1),
                    GetDiagonal(matrix, 0, i, -1)
                };
                diags.ForEach((diag) => {
                    var list = diag.ToList();
                    Console.WriteLine(string.Join(" ", list));
                    double sum = list.Sum();
                    if (list.Count > 0 && sum < minSum) minSum = sum;
                });
            }
            Console.WriteLine("Минимальная сумма элементов диагонали: {0}", minSum);
        }

        static void PrintMatrix(double[][] matrix)
        {
            int len = MaxInMatrix(matrix).ToString().Length;

            Console.WriteLine();
            for (int i = 0; i < matrix.Length; i++)
            {
                Console.Write("|");
                for (int j = 0; j < matrix[i].Length; j++) Console.Write(" {0, " + len + "} ", matrix[i][j]);
                Console.Write("|\n");
            }
            Console.WriteLine();
        }

        static double MaxInMatrix(double[][] matrix)
        {
            double max = double.MinValue;
            foreach (var row in matrix)
            {
                double curMax = row.Max();
                max = curMax > max ? curMax : max;
            }
            return max;
        }

        static IEnumerable<double> GetDiagonal(double[][] matrix, int x, int y, int move = 1)
        {
            while (x < matrix[0].Length && y < matrix.Length && x >= 0 && y >= 0)
            {
                yield return matrix[y][x];
                x += move;
                y += 1;
            }
        }
    }
}
