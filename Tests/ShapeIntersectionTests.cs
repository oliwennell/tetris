using App;
using NUnit.Framework;

namespace Tests
{
    public class ShapeIntersectionTests
    {
        [Test]
        public void Shapes_intersect_when_they_share_a_point()
        {
            var shape1 = new Shape(new[] {new Point(1, 0), new Point(1, 1), new Point(1, 2)});
            var shape2 = new Shape(new[] {new Point(0, 1), new Point(1, 1), new Point(2, 1)});
            
            Assert.That(shape1.DoesShapeIntersectWith(new[] { shape2 }), Is.True);
        }
        
        [Test]
        public void Shapes_intersect_when_they_share_multiple_points()
        {
            var shape1 = new Shape(new[] {new Point(1, 1), new Point(2, 2), new Point(3, 3)});
            var shape2 = new Shape(new[] {new Point(0, 0), new Point(1, 1), new Point(2, 2)});
            
            Assert.That(shape1.DoesShapeIntersectWith(new[] { shape2 }), Is.True);
        }
        
        [Test]
        public void Shapes_intersect_when_they_share_the_same_set_of_points()
        {
            var shape1 = new Shape(new[] {new Point(1, 1), new Point(2, 2), new Point(3, 3)});
            var shape2 = new Shape(new[] {new Point(3, 3), new Point(2, 2), new Point(1, 1)});
            
            Assert.That(shape1.DoesShapeIntersectWith(new[] { shape2 }), Is.True);
        }
        
        [Test]
        public void Shapes_do_intersect_when_they_do_not_share_any_points()
        {
            var shape1 = new Shape(new[] {new Point(1, 0), new Point(1, 1), new Point(1, 2)});
            var shape2 = new Shape(new[] {new Point(10, 11), new Point(11, 11), new Point(12, 11)});
            
            Assert.That(shape1.DoesShapeIntersectWith(new[] { shape2 }), Is.False);
        }
        
        [Test]
        public void Shapes_that_are_parallell_do_not_intersect()
        {
            var shape1 = new Shape(new[] {new Point(1, 0), new Point(1, 1), new Point(1, 2)});
            var shape2 = new Shape(new[] {new Point(2, 0), new Point(2, 1), new Point(2, 2)});
            
            Assert.That(shape1.DoesShapeIntersectWith(new[] { shape2 }), Is.False);
        }
    }
}