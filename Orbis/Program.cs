using OrbisTennisSimulator.BLL;
using System;
using System.Collections.Generic;

namespace Orbis
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Running simulation for Andy vs Dustin");

            var matchFactory = new MatchFactory(new Player("Andy"), new Player("Dustin"));

            var matchResult = matchFactory.MatchSimulator.SimulateMatch();

            Console.WriteLine($"Winner: {matchResult.GetWinner().Name}");

            var score = GetFinalScore(matchResult.GetPlayerScores());

            Console.WriteLine(score);

            Console.ReadKey();
        }

        private static string GetFinalScore(IList<PlayerScore> playerScores)
        {
            return
                $"{playerScores[0].Player.Name} : {playerScores[0].Score}, {playerScores[1].Player.Name} : {playerScores[1].Score}";
        }
    }
}
