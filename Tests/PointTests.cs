using App;
using NUnit.Framework;

namespace Tests
{
    public class PointTests
    {
        [Test]
        public void A_points_string_representation_includes_its_x_and_y_values()
        {
            var point = new Point(1, 2);

            var @string = point.ToString();
            
            Assert.That(@string, Does.Contain("1, 2"));
        }
    }
}