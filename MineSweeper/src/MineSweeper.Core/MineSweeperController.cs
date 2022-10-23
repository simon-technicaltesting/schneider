using Ardalis.GuardClauses;
using MineSweeper.Core.Abstractions;

namespace MineSweeper.Core
{
    public class MineSweeperController : IGameController
    {
        private readonly IPlayerView _playerView;
        private readonly IMineSweeperBoard _mineSweeperBoard;

        private const int StartingLives = 3;
        private const int StartingMines = 20;

        public MineSweeperController(IPlayerView playerView, IMineSweeperBoard mineSweeperBoard)
        {
            _playerView = Guard.Against.Null(playerView, nameof(playerView));
            _mineSweeperBoard = Guard.Against.Null(mineSweeperBoard, nameof(mineSweeperBoard));
        }

        public void Start()
        {
            _playerView.DisplayMessage("Welcome to Mine Sweeper!");

            _mineSweeperBoard.InitialiseGame(StartingLives, StartingMines);

            while (!_mineSweeperBoard.GameOver && !_mineSweeperBoard.HasReachedOtherSide)
            {
                _playerView.DisplayMessage(_mineSweeperBoard.GetSummary());
                var moveDirection = _playerView.GetNextMove();
                var moveResponse = _mineSweeperBoard.MakeMove(moveDirection);
                _playerView.DisplayMessage(moveResponse);
            }

            if (_mineSweeperBoard.HasReachedOtherSide && !_mineSweeperBoard.GameOver)
            {
                _playerView.DisplayMessage(_mineSweeperBoard.GetSummary());
                _playerView.DisplayMessage($"YOU HAVE WON! Your score was {_mineSweeperBoard.Score}!");
                _playerView.EndGame();
            }
            else
            {
                _playerView.DisplayMessage("GAME OVER out of lives!");
                _playerView.EndGame();
            }
        }
    }
}