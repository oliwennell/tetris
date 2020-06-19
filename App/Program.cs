using System;
using System.Linq;

namespace App
{
    class Program
    {
        static void Main(string[] args)
        {
            const int top = 15;
            var world = new World(
                width: 5,
                height: top+1,
                pendingShapes: new []
                {
                    //new Shape(new []{ new Point(2, top+1), new Point(2, top+2), new Point(3, top+2), new Point(4, top+2) }),
                    new Shape(new []{ new Point(1, top+1), new Point(2, top+1), new Point(3, top+1), new Point(3, top+2) }),
                    new Shape(new []{ new Point(1, top+3), new Point(2, top+3), new Point(3, top+3), new Point(4, top+3) }),
                },
                fallingShape: new Shape(new []{ new Point(2, top+1) }),
                staticShapes: new Shape[0]);

            var input = "";
            for (int i = 0; i < 100; i++)
            {
                if (input == "q")
                    world = Game.RotateFallingShapeLeft(world);
                else if (input == "w")
                    world = Game.RotateFallingShapeRight(world);
                else
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
                input = Console.ReadLine();
            }
        }
    }
}