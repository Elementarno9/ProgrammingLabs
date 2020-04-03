using System;

namespace Lab6
{
    class Program
    {
        static void Main(string[] args)
        {
            Rectangle2D rect1 = new Rectangle2D(10, 5, 20, 20);
            Console.WriteLine("Area of rect {0} = {1}", rect1.ToString(), rect1.Area());
            double dx = 6.5, dy = -12, factor = 2;
            rect1.Move(dx, dy).Scale(factor);
            Console.WriteLine("Moved in ({0}, {1}) and scaled x{2} rect {3}: area = {4}", dx, dy, factor, rect1.ToString(), rect1.Area());

            Rectangle2D rect2 = new Rectangle2D(0, 3, 15, 9);
            Console.WriteLine("Intersects with rect {0}: {1} {2}",
                rect2.ToString(), rect1.IsIntersected(rect2) ? "Yes" : "No",
                Rectangle2D.Intersect(rect1, rect2)?.ToString() ?? "");
            rect2.Move(10, 0);
            Console.WriteLine("Intersects with rect {0}: {1} {2}",
                rect2.ToString(), rect1.IsIntersected(rect2) ? "Yes" : "No",
                Rectangle2D.Intersect(rect1, rect2)?.ToString() ?? "");
            Console.WriteLine("Smallest container of both rects: {0}", Rectangle2D.SmallestContainer(rect1, rect2));

        }
    }
}
