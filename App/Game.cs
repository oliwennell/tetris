using System.Collections.Generic;
using System.Linq;

namespace App
{
    public static class Game
    {
        public static World Step(World oldWorld)
        {
            var fallingShape = ApplyGravity(oldWorld.FallingShape);

            var fallingShapeIntersectsStaticShapes = DoesShapeIntersectWithOthers(fallingShape, oldWorld.StaticShapes);
            var fallingShapeIsBelowFloor = fallingShape.Points.Any(p => p.Y < 0);
            
            if (fallingShapeIsBelowFloor || fallingShapeIntersectsStaticShapes)
            {
                var fallingShapeMadeStatic = new Shape(fallingShape).MoveUp();
                var newWorld = new World(oldWorld).WithStaticShape(fallingShapeMadeStatic);

                if (!oldWorld.PendingShapes.Any())
                {
                    return newWorld;
                }
                
                var newFallingShape = oldWorld.PendingShapes.First();
                var remainingPendingShapes = oldWorld.PendingShapes.Skip(1).ToArray();

                return newWorld
                    .WithFallingShape(newFallingShape)
                    .WithPendingShapes(remainingPendingShapes);
            }
            else
            {
                return new World(oldWorld).WithFallingShape(fallingShape);
            }
        }

        private static bool DoesShapeIntersectWithOthers(Shape shapeToTest, IEnumerable<Shape> otherShapes)
        {
            var pointsToTest = shapeToTest.Points;
            var otherPoints = otherShapes.SelectMany(s => s.Points);
            
            foreach (var otherPoint in otherPoints)
            {
                foreach (var pointToTest in pointsToTest)
                {
                    if (pointToTest.Y == otherPoint.Y)
                        return true;
                }
            }

            return false;
        }

        private static Shape ApplyGravity(Shape fallingShape)
        {
            return new Shape(fallingShape).MoveDown();
        }
    }
}