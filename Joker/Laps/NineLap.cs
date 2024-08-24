using Joker.Players;

namespace Joker.Laps;

public record NineLap : Lap
{ 
    public override int Times => 4;

    public override LapType LapType => LapType.Nines;

    public override int Index()
        => 9;

    public override Player Run(Player starter, PlayerGroup players, CardColor? trump)
    {
        var firstCard = starter.FindRandomCard();
        var lapCards = LapCards.Unfold(starter, players, firstCard);

        if (trump.HasValue)
        {
            return players.FindTrumpCardWinner(lapCards, trump.Value);
        }

        Task.Delay(500).GetAwaiter().GetResult();

        return players.FindDominantCardWinner(lapCards);
    }
}