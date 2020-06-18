using System.Collections.Generic;
using System.Linq;

namespace App
{
    public class Shape
    {
        public Point[] Points { get; }

        public Shape(IEnumerable<Point> points) =>
            Points = points.ToArray();
    }
}