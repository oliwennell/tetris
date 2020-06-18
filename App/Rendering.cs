using System.Linq;

namespace App
{
    public static class Rendering
    {
        public static string[] RenderState(State state)
        {
            var rows = new char[state.Height][];

            for (var row = 0; row < state.Height; row++)
            {
                rows[row] = new char[state.Width];
                for (var column = 0; column < state.Width; column++)
                    rows[row][column] = ' ';
            }

            var allPoints = state.StaticShapes.SelectMany(s => s.Points)
                .Concat(state.FallingShape.Points);
            
            foreach (var point in allPoints)
            {
                rows[point.Y][point.X] = 'X';
            }
            
            return rows.Select(r => new string(r))
                .ToArray();
        }
    }
}