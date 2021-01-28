using System;

namespace OrbisTennisSimulator.BLL
{
    public class MatchResult
    {
        public readonly Player MatchWinner;
        public readonly string MatchScore;

        public MatchResult(Player matchWinner, string matchScore)
        {
            MatchWinner = matchWinner ?? throw new ArgumentNullException(nameof(matchWinner));
            MatchScore = matchScore ?? throw new ArgumentNullException(nameof(matchScore));
        }
    }
}
