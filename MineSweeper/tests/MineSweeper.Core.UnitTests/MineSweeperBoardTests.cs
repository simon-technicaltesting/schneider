using AutoFixture;
using AutoFixture.AutoMoq;
using AutoFixture.Idioms;
using MineSweeper.Core.Abstractions;
using Moq;
using Shouldly;

namespace MineSweeper.Core.UnitTests
{
    public class MineSweeperBoardTests
    {
        private readonly Fixture _fixture = new();

        private Mock<IMineGenerator> _mineGenerator = null!;
        private MineSweeperBoard _sut = null!;

        [SetUp]
        public void Setup()
        {
            _mineGenerator = new Mock<IMineGenerator>();

            _sut = new MineSweeperBoard(_mineGenerator.Object);
        }

        [Test]
        public void Ctor_NullDependencies_Throws()
        {
            _fixture.Customize(new AutoMoqCustomization());

            new GuardClauseAssertion(_fixture).Verify(typeof(MineSweeperBoard).GetConstructors());
        }

        [Test]
        public void Ctor_DefaultValues_CorrectlyInitialised()
        {
            _sut.CurrentPosition.ToString().ShouldBe("A1");
            _sut.Lives.ShouldBe(0);
            _sut.Score.ShouldBe(0);
        }
    }
}