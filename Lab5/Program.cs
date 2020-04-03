using System;

namespace Lab5
{
    class Program
    {
        static void Main(string[] args)
        {
            var tree = new BinarySearchTree();
            tree.Add(10, 5);
            tree.Add(5, 4);
            tree.Add(6, 3);
            tree.Add(15, 2);

            Console.WriteLine(tree.Count());

            tree.Remove(10);
        }
    }
}
