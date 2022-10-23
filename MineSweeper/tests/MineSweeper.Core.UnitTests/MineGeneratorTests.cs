using Shouldly;

namespace MineSweeper.Core.UnitTests
{
    public class MineGeneratorTests
    {
        [Test]
        public void GenerateMines_5Mines_ReturnsCorrectLocationCount()
        {
            var mineGenerator = new MineGenerator();

            var mineLocations = mineGenerator.GenerateMines(5);
            
            mineLocations.Count.ShouldBe(5);
        }
    }
}