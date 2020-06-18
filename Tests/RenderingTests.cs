using App;
using NUnit.Framework;

namespace Tests
{
    public class RenderingTests
    {
        [Test]
        public void The_falling_shape_is_rendered_as_text()
        {
            var state = new State(
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

            var renderedText = Rendering.RenderState(state);
            
            Assert.That(renderedText, Is.EquivalentTo(new[]
            {
                "    ",
                "    ",
                " XX ",
                " XX ",
                "    ",
            }));
        }
        
        [Test]
        public void Static_shapes_are_rendered_as_text()
        {
            var state = new State(
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

            var renderedText = Rendering.RenderState(state);
            
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
            var state = new State(
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

            var renderedText = Rendering.RenderState(state);
            
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