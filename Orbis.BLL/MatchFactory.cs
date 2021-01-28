using OrbisTennisSimulator.BLL.Simulators;

namespace OrbisTennisSimulator.BLL
{
    public class MatchFactory
    {
        public readonly IMatchSimulator MatchSimulator;

        public MatchFactory()
        {
            MatchSimulator = 
                new MatchSimulator(new SetSimulator(new GameSimulator(new RandomSimulator())));
        }
    }
}
