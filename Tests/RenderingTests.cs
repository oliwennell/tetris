using App;
using NUnit.Framework;

namespace Tests
{
    public class RenderingTests
    {
        [Test]
        public void The_falling_shape_is_rendered_when_within_the_bounds_of_the_world()
        {
            var world = new World(
                width: 4,
                height: 5,
                pendingShapes: new Shape[0], 
                fallingShape: new Shape(new []
                {
                    new Point(1,2),
                    new Point(2,2),
                    new Point(1,1),
                    new Point(2,1)
                }),
                staticShapes: new Shape[0]
            );

            var renderedText = Rendering.RenderWorld(world);
            
            Assert.That(renderedText, Is.EquivalentTo(new[]
            {
                "    ",
                "    ",
                " XX ",
                " XX ",
                "    ",
            }));
        }
        
        [TestCase(2,6)]
        [TestCase(2,6)]
        [TestCase(2,-1)]
        [TestCase(-1,2)]
        [TestCase(4,2)]
        public void The_falling_shape_is_not_rendered_when_outside_the_bounds_of_the_world(int x, int y)
        {
            var world = new World(
                width: 4,
                height: 5,
                pendingShapes: new Shape[0], 
                fallingShape: new Shape(new [] { new Point(x,y) }),
                staticShapes: new Shape[0]
            );

            var renderedText = Rendering.RenderWorld(world);
            
            Assert.That(renderedText, Is.EquivalentTo(new[]
            {
                "    ",
                "    ",
                "    ",
                "    ",
                "    ",
            }));
        }
        
        [Test]
        public void Static_shapes_are_rendered_as_text()
        {
            var world = new World(
                width: 5,
                height: 5,
                pendingShapes: new Shape[0], 
                fallingShape: new Shape(new Point[0]), 
                staticShapes: new []
                {
                    new Shape(new []
                    {
                        new Point(1,1),
                        new Point(2,1),
                        new Point(1,0),
                        new Point(2,0)
                    }),
                    new Shape(new []
                    {
                        new Point(1,3),
                        new Point(2,3),
                        new Point(3,3),
                        new Point(4,3)
                    })
                }
            );

            var renderedText = Rendering.RenderWorld(world);
            
            Assert.That(renderedText, Is.EquivalentTo(new[]
            {
                "     ",
                " XXXX",
                "     ",
                " XX  ",
                " XX  ",
            }));
        }
        
        [Test]
        public void Pending_shapes_are_not_rendered()
        {
            var world = new World(
                width: 4,
                height: 5,
                pendingShapes: new []
                {
                    new Shape(new []
                    {
                        new Point(1,1),
                        new Point(2,1),
                        new Point(1,0),
                        new Point(2,0)
                    })
                },
                fallingShape: new Shape(new Point[0]), 
                staticShapes: new Shape[0]
            );

            var renderedText = Rendering.RenderWorld(world);
            
            Assert.That(renderedText, Is.EquivalentTo(new[]
            {
                "    ",
                "    ",
                "    ",
                "    ",
                "    ",
            }));
        }
    }
}