using Shouldly;

namespace MineSweeper.Core.UnitTests
{
    public class LocationTests
    {
        [Test]
        public void MoveUp_ReturnsCorrectNotation()
        {
            var location = new Location(1, 1);

            location.MoveUp();

            location.Y.ShouldBe(2);
        }
        
        // Would test other methods

        [Test]
        public void ToString_ReturnsCorrectNotation()
        {
            var location = new Location(1, 1);

            location.ToString().ShouldBe("A1");
        }

        [Test]
        public void Equals_SameLocation_ReturnsTrue()
        {
            var location = new Location(1, 1);
            var location2 = new Location(1, 1);

            location.Equals(location2).ShouldBeTrue();
        }

        [Test]
        public void Equals_DifferentLocation_ReturnsFalse()
        {
            var location = new Location(1, 1);
            var location2 = new Location(1, 2);

            location.Equals(location2).ShouldBeFalse();
        }
    }
}