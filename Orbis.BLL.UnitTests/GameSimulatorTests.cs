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
        public void TestSimulateGame()
        {
            var player = new Player("a");
            var opponent = new Player("b");

            _mockRandomSimulator
                .Setup(x => x.GetRandomInt(2))
                .Returns(0);

            var matchResult = _gameSimulator.SimulateGame(player, opponent);

            Assert.AreEqual("a", matchResult.MatchWinner.Name);
            Assert.AreEqual("5:0", matchResult.FinalScore);
        }
    }
}
