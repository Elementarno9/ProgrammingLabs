using System;

namespace Lab6
{
    class Program
    {
        static void Main(string[] args)
        {
            Rectangle2D rect1 = new Rectangle2D(10, 5, 20, 20);
            Console.WriteLine("Area of rect ({0}, {1}, {2}, {3}) = {4}", rect1.p1.X, rect1.p1.Y, rect1.p2.X, rect1.p2.Y, rect1.Area());
            double dx = 6.5, dy = -12, factor = 2;
            rect1.Move(dx, dy).Scale(factor);
            Console.WriteLine("Moved in ({0}, {1}) and scaled x{2} rect ({3}, {4}, {5}, {6}): area = {7}", dx, dy, factor, rect1.p1.X, rect1.p1.Y, rect1.p2.X, rect1.p2.Y, rect1.Area());

            Rectangle2D rect2 = new Rectangle2D(0, 3, 15, 9);
            Console.WriteLine("Intersects with rect ({0}, {1}, {2}, {3}): {4}", rect2.p1.X, rect2.p1.Y, rect2.p2.X, rect2.p2.Y, rect1.Intersect(rect2) ? "Yes" : "No");
            rect2.Move(10, 0);
            Console.WriteLine("Intersects with rect ({0}, {1}, {2}, {3}): {4}", rect2.p1.X, rect2.p1.Y, rect2.p2.X, rect2.p2.Y, rect1.Intersect(rect2) ? "Yes" : "No");

        }
    }
}
