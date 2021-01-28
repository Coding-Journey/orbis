using System;

namespace OrbisTennisSimulator.BLL.Simulators
{
    public interface ISetSimulator
    {
        public SetResult SimulateSet(Player player, Player opponent);
    }
    public class SetSimulator : ISetSimulator
    {
        private readonly IGameSimulator _gameSimulator;

        public SetSimulator(IGameSimulator gameSimulator)
        {
            _gameSimulator = gameSimulator ?? throw new ArgumentNullException(nameof(gameSimulator));
        }

        public SetResult SimulateSet(Player player, Player opponent)
        {
            var playerSetScore = 0;
            var opponentSetScore = 0;

            var setScore = "";
            var currentGame = 0;

            while(!IsSetOver(playerSetScore, opponentSetScore))
            {
                currentGame++;

                var gameResult = _gameSimulator.SimulateGame(player, opponent);
                if (gameResult.MatchWinner.Id == player.Id)
                {
                    // player won the set
                    playerSetScore++;
                }
                else
                {
                    // opponent won the set
                    opponentSetScore++;
                }

                setScore += $"\nGame {currentGame} score: {gameResult.FinalScore}";
            }

            var isPlayerSetWinner = playerSetScore > opponentSetScore;
            var setWinner = isPlayerSetWinner ? player : opponent;
            
            return new SetResult(setWinner, setScore);
        }

        private static bool IsSetOver(int score1, int score2)
        {
            return
                (score1 >= 6 || score2 >= 6)
                && Math.Abs(score1 - score2) >= 2;
        }
    }
}
