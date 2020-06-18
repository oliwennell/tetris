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
            var stateBefore = new World(
                width: 5,
                height: 5,
                pendingShapes: new Shape[0],
                fallingShape: new Shape(new Point[0]),
                staticShapes: new Shape[0]);

            var stateAfter = Game.Step(stateBefore);
            
            Assert.That(stateAfter.Width, Is.EqualTo(stateBefore.Width));
            Assert.That(stateAfter.Height, Is.EqualTo(stateBefore.Height));
            Assert.That(stateAfter.PendingShapes, Has.Length.Zero);
            Assert.That(stateAfter.FallingShape.Points, Has.Length.Zero);
            Assert.That(stateAfter.StaticShapes, Has.Length.Zero);
        }

        [Test]
        public void A_new_world_is_created_instead_of_the_old_one_being_mutated()
        {
            var stateBefore = new World(
                width: 5,
                height: 5,
                pendingShapes: new Shape[0],
                fallingShape: new Shape(new Point[0]),
                staticShapes: new Shape[0]);

            var stateAfter = Game.Step(stateBefore);
            
            Assert.That(stateAfter, Is.Not.SameAs(stateBefore));
        }

        [Test]
        public void The_designated_falling_shape_falls_downwards_over_time()
        {
            var stateBefore = new World(
                width: 5,
                height: 5,
                pendingShapes: new Shape[0],
                fallingShape: new Shape(new []{ new Point(2, 5) }),
                staticShapes: new Shape[0]);

            var stateAfter1 = Game.Step(stateBefore);
            var stateAfter2 = Game.Step(stateAfter1);
            var stateAfter3 = Game.Step(stateAfter2);
            var stateAfter4 = Game.Step(stateAfter3);
            var stateAfter5 = Game.Step(stateAfter4);
            
            Assert.That(stateAfter1.FallingShape.Points.Single().Y, Is.EqualTo(4));
            Assert.That(stateAfter2.FallingShape.Points.Single().Y, Is.EqualTo(3));
            Assert.That(stateAfter3.FallingShape.Points.Single().Y, Is.EqualTo(2));
            Assert.That(stateAfter4.FallingShape.Points.Single().Y, Is.EqualTo(1));
            Assert.That(stateAfter5.FallingShape.Points.Single().Y, Is.EqualTo(0));
        }
    }

}