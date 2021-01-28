using System;

namespace OrbisTennisSimulator.BLL.Simulators
{
    public interface IGameSimultor
    {
        public GameResult SimulateGame(Player player, Player opponent);
    }
    public class GameSimulator : IGameSimultor
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

            var isPlayerWinner = playerScore > opponentScore;

            var winningPlayer = isPlayerWinner ? player : opponent;
            var finalScore = isPlayerWinner ? $"{playerScore}:{opponentScore}" : $"{opponentScore}:{playerScore}";

            return new GameResult(winningPlayer, finalScore);
        }

        private static bool IsGameOver(int score1, int score2)
        {
            return 
                (score1 > 4 || score2 > 4) 
                && Math.Abs(score1 - score2) >=2;
        }
    }
}
