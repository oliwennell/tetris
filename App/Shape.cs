using System.Collections.Generic;
using System.Linq;

namespace App
{
    public class Shape
    {
        public Point[] Points { get; }

        public Shape(IEnumerable<Point> points) =>
            Points = points.ToArray();

        public Shape(Shape other)
        {
            Points = other.Points.ToArray();
        }

        public Shape MoveDown()
        {
            var result = new Shape(this);

            for (int i = 0; i < result.Points.Length; i++)
            {
                var oldPoint = result.Points[i];
                result.Points[i] = new Point(oldPoint.X, oldPoint.Y - 1);
            }

            return result;
        }
    }
}