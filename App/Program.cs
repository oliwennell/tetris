using System;
using System.Linq;

namespace App
{
    class Program
    {
        static void Main(string[] args)
        {
            var world = new World(
                width: 5,
                height: 5,
                pendingShapes: new []
                {
                    new Shape(new []{ new Point(2, 5), new Point(2, 6), new Point(3, 6), new Point(4, 6) }),
                },
                fallingShape: new Shape(new []{ new Point(2, 5) }),
                staticShapes: new Shape[0]);

            
            for (int i = 0; i < 100; i++)
            {
                world = Simulation.Step(world);

                var renderedWorld = Rendering.RenderWorld(world);
                for (int j = 0; j < renderedWorld.Length; j++)
                {
                    Console.Clear();
                }
                foreach (var line in renderedWorld.Reverse())
                {
                    Console.WriteLine(line);
                }
                
                Console.WriteLine("------------------------------");
                Console.ReadLine();
            }
        }
    }
}