using System.Collections.Generic;

namespace OrbisTennisSimulator.BLL
{
    public interface IScore
    {
        public bool IsOver();
        public void IncrementScore(Player player);
        public Player GetWinner();
        public IList<PlayerScore> GetPlayerScores();
    }
}
