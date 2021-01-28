using System;
using System.Collections.Generic;
using System.Text;
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
        public void TestSimulateSet()
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
            Assert.AreEqual(
                "\nGame 1 score: a 5:0 b\nGame 2 score: a 5:0 b\nGame 3 score: a 5:0 b\nGame 4 score: a 5:0 b\nGame 5 score: a 5:0 b\nGame 6 score: a 5:0 b",
                result.SetScores);

        }
    }
}
