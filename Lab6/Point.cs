using System;
using System.Collections.Generic;
using System.Text;

namespace Lab6
{
    /*
     * OX => right
     * OY => top
     */
    struct Point
    {
        public readonly double X;
        public readonly double Y;

        public Point(double x = 0, double y = 0)
        {
            X = x;
            Y = y;
        }

        public Point Move(double dx, double dy) => new Point(X + dx, Y + dy);
    }
}
