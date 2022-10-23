namespace MineSweeper.Core.Abstractions
{
    public interface IMineSweeperBoard
    {
        int Lives { get; }
        int Score { get; }
        Location CurrentPosition { get; }
        bool GameOver { get; }
        bool HasReachedOtherSide { get; }
        void InitialiseGame(int startingLives, int noOfMines);
        string MakeMove(MoveDirection direction);
        string GetSummary();
    }
}