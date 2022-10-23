namespace MineSweeper.Core.Abstractions
{
    public interface IPlayerView
    {
        void DisplayMessage(string message);
        MoveDirection GetNextMove();
        void EndGame();
    }
}