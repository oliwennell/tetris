namespace App
{
    public static class Game
    {
        public static World Step(World world)
        {
            return new World(world)
                .WithFallingShape(ApplyGravity(world.FallingShape));
        }

        private static Shape ApplyGravity(Shape fallingShape)
        {
            return new Shape(fallingShape).MoveDown();
        }
    }
}