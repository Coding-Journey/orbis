using Moq;
using NUnit.Framework;
using OrbisTennisSimulator.BLL.Simulators;

namespace OrbisTennisSimulator.BLL.UnitTests.Simulators
{
    [TestFixture]
    internal class MatchSimulatorTests
    {
        private MockRepository _repository;
        private Mock<ISetSimulator> _mockSetSimulator;
        private Mock<IScore> _mockMatchScore;
        private MatchSimulator _matchSimulator;

        [SetUp]
        public void SetUp()
        {
            _repository = new MockRepository(MockBehavior.Strict);
            _mockSetSimulator = _repository.Create<ISetSimulator>();
            _matchSimulator = new MatchSimulator(_mockSetSimulator.Object, _mockMatchScore.Object);
        }

        [TearDown]
        public void TearDown()
        {
            _repository.Verify();
        }

        [Test]
        public void TestSimulateMatch()
        {
            var player = new Player("a");
            var opponent = new Player("b");

            SetUpMockScore(true);

            var result = _matchSimulator.SimulateMatch();
        }

        [Test]
        public void TestSimulateMatchPlayerWins()
        {
            var player = new Player("a");
            var opponent = new Player("b");

            SetUpMockScore(false);
            SetUpMockScore(false);
            SetUpMockScore(false);
            SetUpMockScore(false);
            SetUpMockScore(false);
            SetUpMockScore(true);

            _mockMatchScore
                .Setup(x => x.IncrementScore(player))
                .Verifiable();

            var result = _matchSimulator.SimulateMatch();
        }

        private void SetUpMockScore(bool value)
        {
            _mockMatchScore
                .Setup(x => x.IsOver())
                .Returns(value);
        }
    }
}
