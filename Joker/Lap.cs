

namespace Joker;

public record Lap(int Index)
{
    public Player Run(Player starter, Players players, CardColor? trump)
    {
        var firstCard = starter.FindRandomCard();
        LapCards lapCards = LapCards.Unfold(starter, players, firstCard);

        if (trump.HasValue)
        {
            return players.ElementAt(
                lapCards
                    .TryFindTrumpDominantCard(trump.Value)
                    .PlayerIndex
            );
        }

        Task.Delay(1000).GetAwaiter().GetResult();

        return players.ElementAt(
            lapCards
                .TryFindDominantCard()
                .PlayerIndex
        );
    }
}

public class LapCards : List<PlayerCard>
{
    internal PlayerCard TryFindDominantCard()
    {
        var orderedCards = this.OrderBy(card => card.CardIndex);
        return orderedCards?.MaxBy(a => a.Card?.Weight)!;
    }

    internal PlayerCard TryFindTrumpDominantCard(CardColor trump)
    {
        var orderedCards = this.Where(card => card.Card.Color == trump).OrderBy(card => card.CardIndex);
        return orderedCards?.MaxBy(a => a.Card?.Weight ?? 0)!;
    }

    public static LapCards Unfold(Player starter, Players players, Card firstCard)
    {
        LapCards lapCards = [new PlayerCard(firstCard, 0, starter.Index)];

        var waitingPlayerCount = players.Where(a => !a.Starter)
            .Select(a => a.Index)
            .ToArray();

        foreach (var index in waitingPlayerCount)
        {
            var player = players.ElementAt(index);
            var lapCard = player.TryFindSameCardByColor(firstCard.Color, index);
            lapCards.Add(lapCard);
        }

        return lapCards;
    }
}