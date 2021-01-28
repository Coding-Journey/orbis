using System;

namespace OrbisTennisSimulator.BLL.Simulators
{
    public interface IMatchSimulator
    {
        public IScore SimulateMatch();
    }
    public class MatchSimulator : IMatchSimulator
    {
        private readonly ISetSimulator _setSimulator;
        private readonly IScore _matchScore;

        public MatchSimulator(ISetSimulator setSimulator, IScore matchScore)
        {
            _setSimulator = setSimulator ?? throw new ArgumentNullException(nameof(setSimulator));
            _matchScore = matchScore ?? throw new ArgumentNullException(nameof(matchScore));
        }

        public IScore SimulateMatch()
        {
            var player = _matchScore.GetPlayerScores()[0].Player;
            var opponent = _matchScore.GetPlayerScores()[1].Player;

            while(!_matchScore.IsOver())
            {
                var setResult = _setSimulator.SimulateSet(player, opponent);
                if(setResult.GetWinner().Id == player.Id)
                {
                    // player won the set
                    _matchScore.IncrementScore(player);
                }
                else
                {
                    // opponent won the set
                    _matchScore.IncrementScore(opponent);
                }
            }

            return _matchScore;
        }
    }
}
