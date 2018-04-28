using System;

namespace ADO.NET.FormClasses
{
    class Point
    {
        public double X { get; }
        public double Y { get; }
        public double Z { get; }

        public Point(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public double GetDistance(Point another)
        {
            if (another == null) throw new ArgumentNullException();
            else return Math.Sqrt(
                Math.Pow(another.X - X, 2) +
                Math.Pow(another.Y - Y, 2) +
                Math.Pow(another.Z - Z, 2));
        }
    }
}
