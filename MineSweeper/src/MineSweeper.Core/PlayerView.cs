using MineSweeper.Core.Abstractions;

namespace MineSweeper.Core
{
    public class PlayerView : IPlayerView
    {
        public void DisplayMessage(string message)
        {
            Console.WriteLine(message);
        }
        
        public MoveDirection GetNextMove()
        {
            Console.WriteLine("Please press any arrow key: ");
            return Console.ReadKey(true).Key switch
            {
                ConsoleKey.UpArrow => MoveDirection.Up,
                ConsoleKey.DownArrow => MoveDirection.Down,
                ConsoleKey.LeftArrow => MoveDirection.Left,
                ConsoleKey.RightArrow => MoveDirection.Right,
                _ => MoveDirection.Invalid
            };
        }
        
        public void EndGame()
        {
            DisplayMessage("Press any key to close");
            Console.ReadKey(true);
        }
    }
}