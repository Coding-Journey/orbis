using System;

namespace OrbisTennisSimulator.BLL.Simulators
{
    public interface IRandomSimulator
    {
        public int GetRandomInt(int upperBound);
    }

    public class RandomSimulator : IRandomSimulator
    {
        public int GetRandomInt(int upperBound)
        {
            var random = new Random();
            return random.Next(upperBound);
        }
    }
}
