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

        //[Test]
        //public void TestSimulateMatchPlayerWinner()
        //{
        //    var player = new Player("a");
        //    var opponent = new Player("b");
        //
        //    _mockSetSimulator
        //        .Setup(x => x.SimulateSet(player, opponent))
        //        .Returns(new SetScore(player, "scores"));
        //
        //    var result = _matchSimulator.SimulateMatch(player, opponent);
        //
        //    Assert.AreEqual(player.Id, result.MatchWinner.Id);
        //    Assert.AreEqual(
        //        "Match Result: a 2 sets : b 0 sets.\n Congratulations a!",
        //        result.MatchScore);
        //}
    }
}
