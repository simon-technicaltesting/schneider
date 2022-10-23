using AutoFixture;
using AutoFixture.AutoMoq;
using AutoFixture.Idioms;
using MineSweeper.Core.Abstractions;
using Moq;

namespace MineSweeper.Core.UnitTests
{
    public class MineSweeperControllerTests
    {
        private readonly Fixture _fixture = new();
        
        private Mock<IPlayerView> _playerView = null!;
        private Mock<IMineSweeperBoard> _mineSweeperBoard = null!;
        private MineSweeperController _sut = null!;

        [SetUp]
        public void Setup()
        {
            _playerView = new Mock<IPlayerView>();
            _mineSweeperBoard = new Mock<IMineSweeperBoard>();
            
            _sut = new MineSweeperController(_playerView.Object, _mineSweeperBoard.Object);
        }
        
        [Test]
        public void Ctor_NullDependencies_Throws()
        {
            _fixture.Customize(new AutoMoqCustomization());
        
            new GuardClauseAssertion(_fixture).Verify(typeof(MineSweeperController).GetConstructors());
        }
        
        // Test other paths through code
        
        [Test]
        public void Start_GameOver_CorrectMethodsCalled()
        {
            _mineSweeperBoard
                .Setup(x => x.GameOver)
                .Returns(true);
            
            _sut.Start();
            
            _playerView.Verify(x=>x.DisplayMessage("GAME OVER out of lives!"), Times.Once);
            _playerView.Verify(x=>x.EndGame(), Times.Once);
        }
    }
}