using System;
using System.Collections.Generic;
using System.Text;

namespace OrbisTennisSimulator.BLL.Simulators
{
    public interface IMatchSimulator
    {
        public MatchResult SimulateMatch(Player player, Player opponent);
    }
    public class MatchSimulator : IMatchSimulator
    {
        private readonly ISetSimulator _setSimulator;

        public MatchSimulator(ISetSimulator setSimulator)
        {
            _setSimulator = setSimulator ?? throw new ArgumentNullException(nameof(setSimulator));
        }

        public MatchResult SimulateMatch(Player player, Player opponent)
        {
            var playerMatchScore = 0;
            var opponentMatchScore = 0;

            while(!IsMatchOver(playerMatchScore, opponentMatchScore))
            {
                var setResult = _setSimulator.SimulateSet(player, opponent);
                if(setResult.SetWinner.Id == player.Id)
                {
                    // player won the set
                    playerMatchScore++;
                }
                else
                {
                    // opponent won the set
                    opponentMatchScore++;
                }
            }

            var matchWinner = playerMatchScore > opponentMatchScore ? player : opponent;
            var matchScore =
                $"Match Result: {player.Name} {playerMatchScore} sets : {opponent.Name} {opponentMatchScore} sets." +
                $"\n Congratulations {matchWinner.Name}!";

            return new MatchResult(matchWinner, matchScore);
        }

        private static bool IsMatchOver(int score1, int score2)
        {
            return score1 >= 2 || score2 >= 2;
        }
    }
}
