using System;
using OrbisTennisSimulator.BLL.Simulators;

namespace OrbisTennisSimulator.BLL
{
    public class GameResult
    {
        public readonly Player MatchWinner;
        public readonly string FinalScore;

        public GameResult(Player matchWinner, string finalScore)
        {
            MatchWinner = matchWinner ?? throw new ArgumentNullException(nameof(matchWinner));
            FinalScore = finalScore ?? throw new ArgumentNullException(nameof(finalScore));
        }
    }
}