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

        public bool Intersect(Rectangle2D other)
        {
            // Consider x1 > x2, y1 > y2 and etc.
            double x1 = Math.Min(p1.X, p2.X), x2 = Math.Max(p1.X, p2.X),
                y1 = Math.Min(p1.Y, p2.Y), y2 = Math.Max(p1.Y, p2.Y),
                _x1 = Math.Min(other.p1.X, other.p2.X), _x2 = Math.Max(other.p1.X, other.p2.X),
                _y1 = Math.Min(other.p1.Y, other.p2.Y), _y2 = Math.Max(other.p1.Y, other.p2.Y);

            return (_x2 >= x1 && _x1 <= x2) && (_y2 >= y1 && _y1 <= y2);
        }
    }
}
