namespace MineSweeper.Core.Helpers
{
    public static class ChessBoardNotationHelper
    {
        public static string ToChessBoardNotation(int x, int y)
        {
            if (x is < 1 or > 8)
                throw new ArgumentOutOfRangeException(nameof(x));
            
            if (y is < 1 or > 8)
                throw new ArgumentOutOfRangeException(nameof(y));
            
            return char.ConvertFromUtf32(64 + x) + y;
        }
    }
}