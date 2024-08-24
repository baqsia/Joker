using Joker.Players;

namespace Joker.Laps;

public abstract record Lap
{
    public abstract int Index();
    public abstract int Times { get; }
    public abstract LapType LapType { get; }

    public abstract Player Run(Player starter, PlayerGroup players, CardColor? trump);
}
