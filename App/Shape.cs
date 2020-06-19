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

        public Shape MoveDown() => MoveOnYAxis(delta: -1);

        public Shape MoveUp() => MoveOnYAxis(delta: 1);

        private Shape MoveOnYAxis(int delta)
        {
            var result = new Shape(this);

            for (int i = 0; i < result.Points.Length; i++)
            {
                var oldPoint = result.Points[i];
                result.Points[i] = new Point(oldPoint.X, oldPoint.Y + delta);
            }

            return result;
        }

        public bool DoesShapeIntersectWith(IEnumerable<Shape> otherShapes)
        {
            var otherPoints = otherShapes.SelectMany(s => s.Points);
            
            foreach (var otherPoint in otherPoints)
            {
                foreach (var pointToTest in Points)
                {
                    if (pointToTest.X == otherPoint.X &&
                        pointToTest.Y == otherPoint.Y)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}