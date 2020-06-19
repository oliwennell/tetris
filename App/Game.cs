using System.Linq;

namespace App
{
    public static class Game
    {
        public static World Step(World oldWorld)
        {
            var fallingShape = ApplyGravity(oldWorld.FallingShape);
            var hasFallenThroughFloor = fallingShape.Points.Any(p => p.Y < 0);
            if (hasFallenThroughFloor)
            {
                var fallingShapeMadeStatic = new Shape(fallingShape).MoveUp();
                return new World(oldWorld).WithStaticShape(fallingShapeMadeStatic);
            }
            else
            {
                return new World(oldWorld).WithFallingShape(fallingShape);
            }
        }

        private static Shape ApplyGravity(Shape fallingShape)
        {
            return new Shape(fallingShape).MoveDown();
        }
    }
}