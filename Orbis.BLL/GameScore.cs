using System;

namespace OrbisTennisSimulator.BLL
{
    public class GameScore : ScoreBase
    {
        public GameScore(Player player, Player opponent):base(player, opponent)
        { }

        public override bool IsOverCondition(int score1, int score2)
        {
            return
                (score1 >= 5 || score2 >= 5)
                && Math.Abs(score1 - score2) >= 2;
        }
    }
}