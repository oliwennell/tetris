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
                pendingShapes: new Shape[0],
                fallingShape: new Shape(new []{ new Point(2, 5) }),
                staticShapes: new Shape[0]);

            
            for (int i = 0; i < 10; i++)
            {
                world = Game.Step(world);
                var renderedWorld = Rendering.RenderWorld(world);
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