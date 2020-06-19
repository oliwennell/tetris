using System.Linq;
using App;
using NUnit.Framework;

namespace Tests
{
    public class GameTests
    {
        [Test]
        public void An_empty_world_does_not_change()
        {
            var worldBefore = new World(
                width: 5,
                height: 5,
                pendingShapes: new Shape[0],
                fallingShape: new Shape(new Point[0]),
                staticShapes: new Shape[0]);

            var worldAfter = Game.Step(worldBefore);
            
            Assert.That(worldAfter.Width, Is.EqualTo(worldBefore.Width));
            Assert.That(worldAfter.Height, Is.EqualTo(worldBefore.Height));
            Assert.That(worldAfter.PendingShapes, Has.Length.Zero);
            Assert.That(worldAfter.FallingShape.Points, Has.Length.Zero);
            Assert.That(worldAfter.StaticShapes, Has.Length.Zero);
        }

        [Test]
        public void A_new_world_is_created_instead_of_the_old_one_being_mutated()
        {
            var worldBefore = new World(
                width: 5,
                height: 5,
                pendingShapes: new Shape[0],
                fallingShape: new Shape(new Point[0]),
                staticShapes: new Shape[0]);

            var worldAfter = Game.Step(worldBefore);
            
            Assert.That(worldAfter, Is.Not.SameAs(worldBefore));
        }

        [Test]
        public void The_designated_falling_shape_falls_downwards_over_time()
        {
            var worldBefore = new World(
                width: 5,
                height: 5,
                pendingShapes: new Shape[0],
                fallingShape: new Shape(new []{ new Point(2, 5) }),
                staticShapes: new Shape[0]);

            var worldAfter1 = Game.Step(worldBefore);
            var worldAfter2 = Game.Step(worldAfter1);
            var worldAfter3 = Game.Step(worldAfter2);
            var worldAfter4 = Game.Step(worldAfter3);
            var worldAfter5 = Game.Step(worldAfter4);

            Assert.That(worldAfter1.FallingShape.Points.Single().Y, Is.EqualTo(4));
            Assert.That(worldAfter2.FallingShape.Points.Single().Y, Is.EqualTo(3));
            Assert.That(worldAfter3.FallingShape.Points.Single().Y, Is.EqualTo(2));
            Assert.That(worldAfter4.FallingShape.Points.Single().Y, Is.EqualTo(1));
            Assert.That(worldAfter5.FallingShape.Points.Single().Y, Is.EqualTo(0));
        }
    }
}