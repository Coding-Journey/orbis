using System;

namespace OrbisTennisSimulator.BLL
{
    public class Player
    {
        public readonly string Name;
        public int Rank;
        public Guid Id;

        public Player(string name)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Id = Guid.NewGuid();
        }
    }
}