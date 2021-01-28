using System;
using System.Collections.Generic;
using System.Linq;

namespace OrbisTennisSimulator.BLL
{
    public abstract class ScoreBase : IScore
    {
        public abstract bool IsOverCondition(int score1, int score2);
        
        private readonly IList<PlayerScore> _playerScores;
        
        protected ScoreBase(Player player, Player opponent)
        {
            if (player == null)
            {
                throw new ArgumentNullException(nameof(player));
            }

            if (opponent == null)
            {
                throw new ArgumentNullException(nameof(opponent));
            }

            _playerScores = new List<PlayerScore>
            {
                new PlayerScore(player), new PlayerScore(opponent)
            };
        }

        public IList<PlayerScore> GetPlayerScores()
        {
            return _playerScores;
        }

        public Player GetWinner()
        {
            if (!IsOver())
            {
                return null;
            }

            return _playerScores
                .OrderByDescending(playerScore => playerScore.Score)
                .First()
                .Player;
        }

        public void IncrementScore(Player player)
        {
            _playerScores
                .SingleOrDefault(playerScore => playerScore.Player.Id == player.Id)
                .Score++;
        }

        public bool IsOver()
        {
            return IsOverCondition(_playerScores[0].Score, _playerScores[1].Score);
        }
    }
}
