using Moq;
using NUnit.Framework;
using OrbisTennisSimulator.BLL.Simulators;

namespace OrbisTennisSimulator.BLL.UnitTests.Simulators
{
    [TestFixture]
    internal class SetSimulatorTests
    {
        private MockRepository _repository;
        private Mock<IGameSimulator> _mockGameSimulator;
        private SetSimulator _setSimulator;

        [SetUp]
        public void SetUp()
        {
            _repository = new MockRepository(MockBehavior.Strict);
            _mockGameSimulator = _repository.Create<IGameSimulator>();
            _setSimulator = new SetSimulator(_mockGameSimulator.Object);
        }

        [TearDown]
        public void TearDown()
        {
            _repository.Verify();
        }

        [Test]
        public void TestSimulateSetPlayerWins()
        {
            var player = new Player("a");
            var opponent = new Player("b");

            var gameResult = new GameResult(player, "a 5:0 b");

            _mockGameSimulator
                .Setup(x => x.SimulateGame(player, opponent))
                .Returns(gameResult)
                .Verifiable();

            var result = _setSimulator.SimulateSet(player, opponent);

            Assert.AreEqual(player.Id, result.SetWinner.Id);
            Assert.AreEqual("Set Result: a 6 games : b 0 games", result.SetScores);
        }

        [Test]
        public void TestSimulateSetOpponentWins()
        {
            var player = new Player("a");
            var opponent = new Player("b");

            var gameResult = new GameResult(opponent, "a 0:5 b");

            _mockGameSimulator
                .Setup(x => x.SimulateGame(player, opponent))
                .Returns(gameResult)
                .Verifiable();

            var result = _setSimulator.SimulateSet(player, opponent);

            Assert.AreEqual(opponent.Id, result.SetWinner.Id);
            Assert.AreEqual("Set Result: a 0 games : b 6 games", result.SetScores);
        }
    }
}
