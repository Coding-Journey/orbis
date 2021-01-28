using System;

namespace OrbisTennisSimulator.BLL
{
    public class SetScore : ScoreBase
    {
        public SetScore(Player player, Player opponent) : base(player, opponent)
        { }

        public override bool IsOverCondition(int score1, int score2)
        {
            return
                (score1 >= 6 || score2 >= 6)
                && Math.Abs(score1 - score2) >= 2;
        }
    }
}
