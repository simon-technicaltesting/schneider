using Ardalis.GuardClauses;
using MineSweeper.Core.Abstractions;

namespace MineSweeper.Core
{
    public class MineSweeperBoard : IMineSweeperBoard
    {
        private List<Location> _mines = new();
        private readonly IMineGenerator _mineGenerator;

        private const string InvalidMoveEdgeOfBoardMessage = "Invalid Move as at edge of board";
        private const string MineHitLifeLostMessage = "Mine hit, life lost!";

        public int Lives { get; private set; }
        public int Score { get; private set; }
        public Location CurrentPosition { get; }

        public bool GameOver => Lives < 0;
        public bool HasReachedOtherSide => CurrentPosition.X > 7;

        public MineSweeperBoard(IMineGenerator mineGenerator)
        {
            _mineGenerator = Guard.Against.Null(mineGenerator, nameof(mineGenerator));

            CurrentPosition = new Location(1, 1);
        }

        public void InitialiseGame(int startingLives, int noOfMines)
        {
            Lives = startingLives;
            _mines = _mineGenerator.GenerateMines(noOfMines);
        }

        public string MakeMove(MoveDirection direction)
        {
            return direction switch
            {
                MoveDirection.Up => MoveUp(),
                MoveDirection.Down => MoveDown(),
                MoveDirection.Left => MoveLeft(),
                MoveDirection.Right => MoveRight(),
                _ => "INVALID input please use arrows keys!"
            };
        }

        public string GetSummary()
        {
            return $"Currently on {CurrentPosition}, with {Lives} lives remaining and {Score} moves taken";
        }

        private string MoveUp()
        {
            if (CurrentPosition.Y > 7)
            {
                return InvalidMoveEdgeOfBoardMessage;
            }

            Score++;
            CurrentPosition.MoveUp();
            
            return CheckForMineHit(() => CurrentPosition.MoveDown());
        }

        private string MoveDown()
        {
            if (CurrentPosition.Y == 1)
            {
                return InvalidMoveEdgeOfBoardMessage;
            }

            Score++;
            CurrentPosition.MoveDown();
            
            return CheckForMineHit(() => CurrentPosition.MoveUp());
        }

        private string MoveRight()
        {
            if (CurrentPosition.X > 7)
            {
                return InvalidMoveEdgeOfBoardMessage;
            }

            Score++;
            CurrentPosition.MoveLeft();

            return CheckForMineHit(() => CurrentPosition.MoveRight());
        }

        private string MoveLeft()
        {
            if (CurrentPosition.X == 1)
            {
                return InvalidMoveEdgeOfBoardMessage;
            }

            Score++;
            CurrentPosition.MoveRight();
            
            return CheckForMineHit(() => CurrentPosition.MoveLeft());
        }

        private string CheckForMineHit(Action revertMove)
        {
            if (!_mines.Contains(CurrentPosition))
            {
                return "";
            }

            Lives--;
            revertMove();
            return MineHitLifeLostMessage;
        }
    }
}