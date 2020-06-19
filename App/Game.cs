namespace App
{
    public static class Game
    {
        public static World Step(World oldWorld)
        {
            return new World(oldWorld)
                .WithFallingShape(ApplyGravity(oldWorld.FallingShape));
        }

        private static Shape ApplyGravity(Shape fallingShape)
        {
            return new Shape(fallingShape).MoveDown();
        }
    }
}