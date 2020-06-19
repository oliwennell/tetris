using System;
using System.Linq;

namespace App
{
    public static class Game
    {
        public static World RotateFallingShapeLeft(World oldWorld)
        {
            const double angleInRadians = Math.PI * 0.5;
            return new World(oldWorld)
                .WithFallingShape(RotateShape(oldWorld.FallingShape, angleInRadians));
        }
        
        
        public static World RotateFallingShapeRight(World oldWorld)
        {
            const double angleInRadians = -(Math.PI * 0.5);
            return new World(oldWorld)
                .WithFallingShape(RotateShape(oldWorld.FallingShape, angleInRadians));
        }

        private static Shape RotateShape(Shape shape, double angleInRadians)
        {
            var midPoint = MidPoint(shape.Points);
            var newPoints = shape.Points.Select(p => RotatePoint(p, midPoint, angleInRadians));
            return new Shape(newPoints);
        }

        private static Point RotatePoint(Point point, Point pivot, double angleInRadians)
        {   
            var pointAtOrigin = new Point(
                point.X - pivot.X,
                point.Y - pivot.Y);
            
            var pointRotatedAroundOrigin = new Point(
                (int)(pointAtOrigin.X * Math.Cos(angleInRadians) - pointAtOrigin.Y * Math.Sin(angleInRadians)),
                (int)(pointAtOrigin.X * Math.Sin(angleInRadians) - pointAtOrigin.Y * Math.Cos(angleInRadians)));
            
            var pointRotatedAroundPivot = new Point(
                pointRotatedAroundOrigin.X + pivot.X,
                pointRotatedAroundOrigin.Y + pivot.Y);

            return pointRotatedAroundPivot;
        }

        private static Point MidPoint(Point[] points)
        {
            return new Point(
                (int)points.Average(p => p.X),
                (int)points.Average(p => p.Y));
        }
    }
}