using MineSweeper.Core.Helpers;
using Shouldly;

namespace MineSweeper.Core.UnitTests.Helpers
{
    public class ChessBoardNotationHelperTests
    {
        [TestCase(0)]
        [TestCase(9)]
        public void ToChessBoardNotation_InvalidXValue_ThrowsArgumentOutOfRangeException(int invalidXValue)
        {
            var argumentOutOfRangeException =  Should.Throw<ArgumentOutOfRangeException>( () => ChessBoardNotationHelper.ToChessBoardNotation(invalidXValue,1));
            
            argumentOutOfRangeException.Message.ShouldBe("Specified argument was out of the range of valid values. (Parameter 'x')");
        }
        
        [TestCase(0)]
        [TestCase(9)]
        public void ToChessBoardNotation_InvalidYValue_ThrowsArgumentOutOfRangeException(int invalidYValue)
        {
            var argumentOutOfRangeException =  Should.Throw<ArgumentOutOfRangeException>( () => ChessBoardNotationHelper.ToChessBoardNotation(1,invalidYValue));
            
            argumentOutOfRangeException.Message.ShouldBe("Specified argument was out of the range of valid values. (Parameter 'y')");
        }
        
        [Test]
        public void ToChessBoardNotation_ReturnsCorrectNotation()
        {
            var result = ChessBoardNotationHelper.ToChessBoardNotation(1,1);

            result.ShouldBe("A1");
        }
    }
}