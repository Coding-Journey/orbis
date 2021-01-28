using System;

namespace OrbisTennisSimulator.BLL.Simulators
{
    public interface IGameSimulator
    {
        public GameResult SimulateGame(Player player, Player opponent);
    }
    public class GameSimulator : IGameSimulator
    {
        private readonly IRandomSimulator _randomSimulator;

        public GameSimulator(IRandomSimulator randomSimulator)
        {
            _randomSimulator = randomSimulator ?? throw new ArgumentNullException(nameof(randomSimulator));
        }

        public GameResult SimulateGame(Player player, Player opponent)
        {
            var playerScore = 0;
            var opponentScore = 0;

            while (!IsGameOver(playerScore, opponentScore))
            {
                if (_randomSimulator.GetRandomInt(2) == 0)
                {
                    //player wins point
                    playerScore++;
                }
                else
                {
                    //opponent wins point
                    opponentScore++;
                }
            }
            
            var winningPlayer = playerScore > opponentScore ? player : opponent;
            var finalScore = $"{player.Name} {playerScore}:{opponentScore} {opponent.Name}";

            return new GameResult(winningPlayer, finalScore);
        }

        private static bool IsGameOver(int score1, int score2)
        {
            return 
                (score1 >= 5 || score2 >= 5) 
                && Math.Abs(score1 - score2) >=2;
        }
    }
}
