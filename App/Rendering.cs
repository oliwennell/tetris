using System.Linq;

namespace App
{
    public static class Rendering
    {
        public static string[] RenderWorld(World world)
        {
            var rows = new char[world.Height][];

            for (var row = 0; row < world.Height; row++)
            {
                rows[row] = new char[world.Width];
                for (var column = 0; column < world.Width; column++)
                    rows[row][column] = ' ';
            }

            var allPoints = world.StaticShapes.SelectMany(s => s.Points)
                .Concat(world.FallingShape.Points);
            
            foreach (var point in allPoints.Where(p => IsWithinBoundsOfWorld(p, world)))
            {
                rows[point.Y][point.X] = 'X';
            }
            
            return rows.Select(r => new string(r))
                .ToArray();
        }

        private static bool IsWithinBoundsOfWorld(Point point, World world)
        {
            return point.X >= 0 && point.X < world.Width &&
                   point.Y >= 0 && point.Y < world.Height;
        }
    }
}