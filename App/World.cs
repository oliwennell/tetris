using System.Collections.Generic;
using System.Linq;

namespace App
{
    public class World
    {
        public uint Width { get; }
        public uint Height { get; }
        
        public Shape[] PendingShapes { get; }
        public Shape FallingShape { get; private set; }
        public Shape[] StaticShapes { get; private set; }

        public World(
            uint width,
            uint height,
            IEnumerable<Shape> pendingShapes,
            Shape fallingShape,
            IEnumerable<Shape> staticShapes)
        {
            Width = width;
            Height = height;
            PendingShapes = pendingShapes.ToArray();
            FallingShape = fallingShape;
            StaticShapes = staticShapes.ToArray();
        }

        public World(World other) :
            this(other.Width, other.Height, other.PendingShapes, other.FallingShape, other.StaticShapes)
        {
        }

        public World WithFallingShape(Shape fallingShape) => new World(this) { FallingShape = fallingShape };

        public World WithStaticShape(Shape fallingShape)
        {
            var newWorld = new World(this);
            newWorld.StaticShapes = newWorld.StaticShapes.Concat(new[] {fallingShape}).ToArray();
            return newWorld;
        }
    }
}