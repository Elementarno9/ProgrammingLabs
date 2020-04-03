using System;
using System.Collections.Generic;
using System.Text;

namespace Lab6
{
    class Rectangle2D
    {
        public Point p1 { get; private set; }
        public Point p2 { get; private set; }

        public Rectangle2D(Point p1, Point p2)
        {
            this.p1 = p1;
            this.p2 = p2;
        }

        public Rectangle2D(double x1, double y1, double x2, double y2)
            : this(new Point(x1,y1), new Point(x2,y2))
        {

        }

        public Rectangle2D Move(double dx, double dy)
        {
            p1 = p1.Move(dx, dy);
            p2 = p2.Move(dx, dy);
            return this;
        }

        public Rectangle2D Scale(double factor)
        {
            p2 = new Point(p1.X + (p2.X - p1.X) * factor, p1.Y + (p2.Y - p1.Y) * factor);
            return this;
        }

        public double Area()
        {
            return Math.Abs(p2.X - p1.X) * Math.Abs(p2.Y - p1.Y);
        }

        public Point GetLeftBottomPoint() => new Point(Math.Min(p1.X, p2.X), Math.Min(p1.Y, p2.Y));
        public Point GetLeftTopPoint() => new Point(Math.Min(p1.X, p2.X), Math.Max(p1.Y, p2.Y));
        public Point GetRightBottomPoint() => new Point(Math.Max(p1.X, p2.X), Math.Min(p1.Y, p2.Y));
        public Point GetRightTopPoint() => new Point(Math.Max(p1.X, p2.X), Math.Max(p1.Y, p2.Y));

        public bool IsIntersected(Rectangle2D other)
        {
            Point lb1 = GetLeftBottomPoint(), rt1 = GetRightTopPoint(),
                   lb2 = other.GetLeftBottomPoint(), rt2 = other.GetRightTopPoint();

            return (rt2.X >= lb1.X && lb2.X <= rt1.X) && (rt2.Y >= lb1.Y && lb2.Y <= rt1.Y);
        }
        public static Rectangle2D Intersect(Rectangle2D rect1, Rectangle2D rect2)
        {
            if (!rect1.IsIntersected(rect2)) return null;

            Point lb1 = rect1.GetLeftBottomPoint(), rt1 = rect1.GetRightTopPoint(),
                  lb2 = rect2.GetLeftBottomPoint(), rt2 = rect2.GetRightTopPoint();

            return new Rectangle2D(new Point(Math.Max(lb1.X, lb2.X), Math.Max(lb1.Y, lb2.Y)), new Point(Math.Min(rt1.X, rt2.X), Math.Min(rt1.Y, rt2.Y)));
        }

        public static Rectangle2D SmallestContainer(Rectangle2D rect1, Rectangle2D rect2)
        {

            Point lb1 = rect1.GetLeftBottomPoint(), rt1 = rect1.GetRightTopPoint(),
                   lb2 = rect2.GetLeftBottomPoint(), rt2 = rect2.GetRightTopPoint();

            return new Rectangle2D(new Point(Math.Min(lb1.X, lb2.X), Math.Min(lb1.Y, lb2.Y)), new Point(Math.Max(rt1.X, rt2.X), Math.Max(rt1.Y, rt2.Y)));
        }

        public override string ToString() => $"({p1.X}, {p1.Y}, {p2.X}, {p2.Y})";
    }
}
