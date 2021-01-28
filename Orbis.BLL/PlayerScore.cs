using System;

namespace OrbisTennisSimulator.BLL
{
    public class PlayerScore
    {
        public readonly Player Player;
        public int Score;

        public PlayerScore(Player player)
        {
            Player = player ?? throw new ArgumentNullException(nameof(player));
            Score = 0;
        }
    }
}
