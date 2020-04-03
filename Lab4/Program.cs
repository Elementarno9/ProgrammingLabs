using System;
using System.IO;

namespace Lab4
{
    class Program
    {
        const int maxLength = 4;

        static void Main(string[] args)
        {
            if (args.Length < 1)
            {
                Console.WriteLine("Ошибка! Необходимо передать путь до файла во время вызова программы.");
                return;
            }

            string text = ReadText(args[0]);
            if (text.Length == 0)
            {
                Console.WriteLine("Ошибка! Не найден текст");
                return;
            }
            int count = CountWords(text, maxLength);

            Console.WriteLine("Слов длинной меньше {0}: {1}", maxLength + 1, count);
        }

        static string ReadText(string path)
        {
            if (!File.Exists(path))
            {
                Console.WriteLine("Ошибка! Несуществующий файл.");
                return "";
            }

            using (var reader = new StreamReader(path))
            {
                return reader.ReadToEnd();
            }

        }

        static int CountWords(string line, int maxLength = 4)
        {
            int count = 0;
            foreach (var word in line.Split())
            {
                if (word.Length <= maxLength) count++;
            }
            return count;
        }   
    }
}
