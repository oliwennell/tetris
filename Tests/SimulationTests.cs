using System.Linq;
using App;
using NUnit.Framework;

namespace Tests
{
    public class SimulationTests
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

            var worldAfter = Simulation.Step(worldBefore);
            
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

            var worldAfter = Simulation.Step(worldBefore);
            
            Assert.That(worldAfter, Is.Not.SameAs(worldBefore));
        }

        [Test]
        public void The_falling_shape_falls_downwards_over_time()
        {
            var worldBefore = new World(
                width: 5,
                height: 5,
                pendingShapes: new Shape[0],
                fallingShape: new Shape(new []{ new Point(2, 5) }),
                staticShapes: new Shape[0]);

            var worldAfter1 = Simulation.Step(worldBefore);
            var worldAfter2 = Simulation.Step(worldAfter1);
            var worldAfter3 = Simulation.Step(worldAfter2);
            var worldAfter4 = Simulation.Step(worldAfter3);
            var worldAfter5 = Simulation.Step(worldAfter4);

            Assert.That(worldAfter1.FallingShape.Points.Single().Y, Is.EqualTo(4));
            Assert.That(worldAfter2.FallingShape.Points.Single().Y, Is.EqualTo(3));
            Assert.That(worldAfter3.FallingShape.Points.Single().Y, Is.EqualTo(2));
            Assert.That(worldAfter4.FallingShape.Points.Single().Y, Is.EqualTo(1));
            Assert.That(worldAfter5.FallingShape.Points.Single().Y, Is.EqualTo(0));
        }

        [Test]
        public void When_the_falling_shape_touches_the_ground_it_becomes_static_on_the_next_step()
        {
            var world = new World(
                width: 5,
                height: 5,
                pendingShapes: new Shape[0],
                fallingShape: new Shape(new []{ new Point(2, 1) }),
                staticShapes: new Shape[0]);

            world = Simulation.Step(world);
            world = Simulation.Step(world);

            Assert.That(world.StaticShapes.Length, Is.EqualTo(1));
            Assert.That(world.StaticShapes.Single().Points.Single(),
                Is.EqualTo(new Point(2,0)));
        }
        
        [Test]
        public void When_the_falling_shape_intersects_with_a_static_shape_it_becomes_static_too()
        {
            var world = new World(
                width: 5,
                height: 5,
                pendingShapes: new Shape[0],
                fallingShape: new Shape(new []{ new Point(2, 3) }),
                staticShapes: new []{ new Shape(new []{ new Point(2, 0), new Point(2, 1) }) });

            world = Simulation.Step(world);
            world = Simulation.Step(world);

            Assert.That(world.StaticShapes.Length, Is.EqualTo(2));
            Assert.That(world.StaticShapes.Last().Points.Single(),
                Is.EqualTo(new Point(2,2)));
        }

        [Test]
        public void After_one_falling_shape_reaches_the_ground_the_next_pending_shape_starts_to_fall()
        {
            var pendingShape = new Shape(new []{ new Point(2, 5) });
            var world = new World(
                width: 5,
                height: 5,
                pendingShapes: new []{ pendingShape },
                fallingShape: new Shape(new []{ new Point(2, 1) }),
                staticShapes: new Shape[0]);

            world = Simulation.Step(world);
            world = Simulation.Step(world);

            Assert.That(world.PendingShapes.Length, Is.EqualTo(0));
            Assert.That(world.FallingShape.Points.Single(),
                Is.EqualTo(pendingShape.Points.Single()));
        }
        
        [Test]
        public void After_one_falling_shape_intersects_with_a_static_shape_the_next_pending_shape_starts_to_fall()
        {
            var pendingShape = new Shape(new []{ new Point(2, 5) });
            var world = new World(
                width: 5,
                height: 5,
                pendingShapes: new []{ pendingShape },
                fallingShape: new Shape(new []{ new Point(2, 3) }),
                staticShapes: new []{ new Shape(new []{ new Point(2, 0), new Point(2, 1) }) });

            world = Simulation.Step(world);
            world = Simulation.Step(world);

            Assert.That(world.PendingShapes.Length, Is.EqualTo(0));
            Assert.That(world.FallingShape.Points.Single(),
                Is.EqualTo(pendingShape.Points.Single()));
        }
        
        [Test]
        public void Static_shapes_do_not_move()
        {
            var shapeBefore = new Shape(new[] { new Point(2, 5) });
            var worldBefore = new World(
                width: 5,
                height: 5,
                pendingShapes: new Shape[0],
                fallingShape: new Shape(new Point[0]),
                staticShapes: new []{ shapeBefore }
            );

            var worldAfter = Simulation.Step(worldBefore);
            var shapeAfter = worldAfter.StaticShapes.Single();
            
            Assert.That(shapeAfter.Points.Single().X, Is.EqualTo(shapeBefore.Points.Single().X));
            Assert.That(shapeAfter.Points.Single().Y, Is.EqualTo(shapeBefore.Points.Single().Y));
        }
    }
}