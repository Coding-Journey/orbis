using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using NUnit.Framework;
using OrbisTennisSimulator.BLL.Simulators;

namespace OrbisTennisSimulator.BLL.UnitTests
{
    [TestFixture]
    internal class GameSimulatorTests
    {
        private MockRepository _repository;
        private Mock<IRandomSimulator> _mockRandomSimulator;
        private GameSimulator _gameSimulator;

        [SetUp]
        public void SetUp()
        {
            _repository = new MockRepository(MockBehavior.Strict);
            _mockRandomSimulator = _repository.Create<IRandomSimulator>();
            _gameSimulator = new GameSimulator(_mockRandomSimulator.Object);
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

            var matchResult = _gameSimulator.SimulateGame(player, opponent);

            Assert.AreEqual(player.Id, matchResult.MatchWinner.Id);
            Assert.AreEqual("a", matchResult.MatchWinner.Name);
            Assert.AreEqual("a 5:0 b", matchResult.FinalScore);
        }

        [Test]
        public void TestSimulateGameOpponentWins()
        {
            var player = new Player("a");
            var opponent = new Player("b");

            _mockRandomSimulator
                .Setup(x => x.GetRandomInt(2))
                .Returns(1);

            var matchResult = _gameSimulator.SimulateGame(player, opponent);

            Assert.AreEqual(opponent.Id, matchResult.MatchWinner.Id);
            Assert.AreEqual("b", matchResult.MatchWinner.Name);
            Assert.AreEqual("a 0:5 b", matchResult.FinalScore);
        }
    }
}
