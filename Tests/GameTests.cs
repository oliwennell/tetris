using App;
using NUnit.Framework;

namespace Tests
{
    public class GameTests
    {
        [Test]
        public void Falling_shape_can_be_rotated_leftwards_around_its_mid_point()
        {
            var worldBefore = new World(
                width: 5,
                height: 5,
                pendingShapes: new Shape[0],
                fallingShape: new Shape(new []{ new Point(1, 1), new Point(2, 1), new Point(3, 1) }),
                staticShapes: new Shape[0]);

            var worldAfter = Game.RotateFallingShapeLeft(worldBefore);
            
            Assert.That(worldAfter.FallingShape.Points,
                Is.EquivalentTo(new[]
                {
                    new Point(2, 0), new Point(2, 1), new Point(2, 2)
                }));
        }
        
        [Test]
        public void Falling_shape_can_be_rotated_rightwards_around_its_mid_point()
        {
            var worldBefore = new World(
                width: 5,
                height: 5,
                pendingShapes: new Shape[0],
                fallingShape: new Shape(new []{ new Point(1, 1), new Point(2, 1), new Point(3, 1) }),
                staticShapes: new Shape[0]);

            var worldAfter = Game.RotateFallingShapeRight(worldBefore);
            
            Assert.That(worldAfter.FallingShape.Points,
                Is.EquivalentTo(new[]
                {
                    new Point(2, 2), new Point(2, 1), new Point(2, 0)
                }));
        }
    }
}