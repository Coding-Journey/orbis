using System;
using System.Linq;
using Moq;
using NUnit.Framework;
using OrbisTennisSimulator.BLL.Simulators;

namespace OrbisTennisSimulator.BLL.UnitTests.Simulators
{
    [TestFixture]
    internal class GameSimulatorTests
    {
        private MockRepository _repository;
        private Mock<IRandomSimulator> _mockRandomSimulator;
        private Mock<IScore> _mockScore;
        private GameSimulator _gameSimulator;

        [SetUp]
        public void SetUp()
        {
            _repository = new MockRepository(MockBehavior.Strict);
            _mockRandomSimulator = _repository.Create<IRandomSimulator>();
            _mockScore = _repository.Create<IScore>();
            _gameSimulator = new GameSimulator(_mockRandomSimulator.Object, _mockScore.Object);
        }

        [TearDown]
        public void TearDown()
        {
            _repository.Verify();
        }

        [Test]
        public void TestSimulateGamePlayerWins()
        {
            var player = new Player("a");
            var opponent = new Player("b");

            _mockRandomSimulator
                .Setup(x => x.GetRandomInt(2))
                .Returns(0);

            SetUpMockScore(false);
            SetUpMockScore(false);
            SetUpMockScore(false);
            SetUpMockScore(false);
            SetUpMockScore(true);

            _mockScore
                .Setup(x => x.IncrementScore(player))
                .Verifiable();

            _mockScore
                .Setup(x => x.GetWinner())
                .Returns(player);

            var result = _gameSimulator.SimulateGame(player, opponent);
        }

        private void SetUpMockScore(bool value)
        {
            _mockScore
                .Setup(x => x.IsOver())
                .Returns(value);
        }
    }
}
