namespace OrbisTennisSimulator.BLL
{
    public class MatchScore : ScoreBase
    {
        public MatchScore(Player player, Player opponent) : base(player, opponent)
        { }

        public override bool IsOverCondition(int score1, int score2)
        {
            return score1 >= 2 || score2 >= 2;
        }
    }
}
