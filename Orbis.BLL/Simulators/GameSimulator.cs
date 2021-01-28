using System;

namespace OrbisTennisSimulator.BLL.Simulators
{
    public interface IGameSimulator
    {
        public IScore SimulateGame(Player player, Player opponent);
    }
    public class GameSimulator : IGameSimulator
    {
        private readonly IRandomSimulator _randomSimulator;
        private readonly IScore _gameScore;

        public GameSimulator(IRandomSimulator randomSimulator, IScore gameScore)
        {
            _randomSimulator = randomSimulator ?? throw new ArgumentNullException(nameof(randomSimulator));
            _gameScore = gameScore ?? throw new ArgumentNullException(nameof(gameScore));
        }

        public IScore SimulateGame(Player player, Player opponent)
        {
            while (!_gameScore.IsOver())
            {
                if (_randomSimulator.GetRandomInt(2) == 0)
                {
                    //player wins point
                    _gameScore.IncrementScore(player);
                }
                else
                {
                    //opponent wins point
                    _gameScore.IncrementScore(opponent);
                }
            }

            return _gameScore;
        }
    }
}
