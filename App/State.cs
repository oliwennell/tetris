using System.Collections.Generic;
using System.Linq;

namespace App
{
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
}