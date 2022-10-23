namespace MineSweeper.Core.Abstractions
{
    public interface IMineGenerator
    {
        List<Location> GenerateMines(int noOfMines);
    }
}