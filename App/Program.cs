using System;
using System.Collections.Generic;
using System.Linq;

namespace App
{
    public class Point
    {
        public int X { get; }
        public int Y { get; }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
    
    public class Shape
    {
        public Point[] Points { get; }

        public Shape(IEnumerable<Point> points) =>
            Points = points.ToArray();
    }

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
    
    public class State
    {
        public uint Width { get; }
        public uint Height { get; }
        
        public Shape[] PendingShapes { get; }
        public Shape FallingShape { get; }
        public Shape[] StaticShapes { get; }

        public State(
            uint width,
            uint height,
            IEnumerable<Shape> pendingShapes,
            Shape fallingShape,
            IEnumerable<Shape> staticShapes)
        {
            Width = width;
            Height = height;
            FallingShape = fallingShape;
            StaticShapes = staticShapes.ToArray();
        }
    }
    
    public static class Game
    {
        public static State Step(State state)
        {
            return null;
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}