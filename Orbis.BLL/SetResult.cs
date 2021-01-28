using System;

namespace OrbisTennisSimulator.BLL
{
    public class SetResult
    {
        public readonly Player SetWinner;
        public readonly string SetScores;

        public SetResult(Player setWinner, string setScores)
        {
            SetWinner = setWinner ?? throw new ArgumentNullException(nameof(setWinner));
            SetScores = setScores ?? throw new ArgumentNullException(nameof(setScores));
        }
    }
}
