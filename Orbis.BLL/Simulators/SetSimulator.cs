using System;

namespace OrbisTennisSimulator.BLL.Simulators
{
    public interface ISetSimulator
    {
        public IScore SimulateSet(Player player, Player opponent);
    }

    public class SetSimulator : ISetSimulator
    {
        private readonly IGameSimulator _gameSimulator;
        private readonly IScore _setScore;

        public SetSimulator(IGameSimulator gameSimulator, IScore setScore)
        {
            _gameSimulator = gameSimulator ?? throw new ArgumentNullException(nameof(gameSimulator));
            _setScore = setScore ?? throw new ArgumentNullException(nameof(setScore));
        }

        public IScore SimulateSet(Player player, Player opponent)
        {
            while(!_setScore.IsOver())
            {
                var gameResult = _gameSimulator.SimulateGame(player, opponent);

                if (gameResult.GetWinner().Id == player.Id)
                {
                    // player won the set
                    _setScore.IncrementScore(player);
                }
                else
                {
                    // opponent won the set
                    _setScore.IncrementScore(opponent);
                }
            }

            return _setScore;
        }
    }
}
