using OrbisTennisSimulator.BLL.Simulators;

namespace OrbisTennisSimulator.BLL
{
    public class MatchFactory
    {
        public readonly IMatchSimulator MatchSimulator;

        public MatchFactory(Player player, Player opponent)
        {
            MatchSimulator = 
                new MatchSimulator(
                    new SetSimulator(
                        new GameSimulator(
                            new RandomSimulator(),
                            new GameScore(player, opponent)),
                        new SetScore(player, opponent)),
                    new MatchScore(player, opponent));
        }
    }
}
