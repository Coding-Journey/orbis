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
        private Mock<IScore> _mockSetScore;
        private SetSimulator _setSimulator;

        [SetUp]
        public void SetUp()
        {
            _repository = new MockRepository(MockBehavior.Strict);
            _mockGameSimulator = _repository.Create<IGameSimulator>();
            _mockSetScore = _repository.Create<IScore>();
            _setSimulator = new SetSimulator(_mockGameSimulator.Object, _mockSetScore.Object);
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

            SetUpMockScore(true);

            var result = _setSimulator.SimulateSet(player, opponent);
        }

        [Test]
        public void TestSimulateSetPlayerWins()
        {
            var player = new Player("a");
            var opponent = new Player("b");

            SetUpMockScore(false);
            SetUpMockScore(false);
            SetUpMockScore(false);
            SetUpMockScore(false);
            SetUpMockScore(false);
            SetUpMockScore(true);

            _mockSetScore
                .Setup(x => x.IncrementScore(player))
                .Verifiable();

            var result = _setSimulator.SimulateSet(player, opponent);
        }

        private void SetUpMockScore(bool value)
        {
            _mockSetScore
                .Setup(x => x.IsOver())
                .Returns(value);
        }
    }
}
