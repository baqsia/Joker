using Joker.Players;

namespace Joker.Laps;

public record OneEightLap : Lap
{
    private int index = 8;
 
    public override int Times => 8;
    public override LapType LapType => LapType.IncementalEights;

    public override int Index()
    {
        var temp = index;
        index--;
        return temp;
    }

    public override Player Run(Player starter, PlayerGroup players, CardColor? trump)
    {
        var firstCard = starter.FindRandomCard();
        var lapCards = LapCards.Unfold(starter, players, firstCard);

        if (trump.HasValue)
        {
            return players.ElementAt(
                lapCards
                    .TryFindTrumpDominantCard(trump.Value)
                    .PlayerIndex
            );
        }

        Task.Delay(500).GetAwaiter().GetResult();

        return players.ElementAt(
            lapCards
                .TryFindDominantCard()
                .PlayerIndex
        );
    }
}