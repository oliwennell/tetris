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
            
            foreach (var point in allPoints)
            {
                rows[point.Y][point.X] = 'X';
            }
            
            return rows.Select(r => new string(r))
                .ToArray();
        }
    }
}