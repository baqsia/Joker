using Joker.Players;

namespace Joker.Laps;

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

    public static LapCards Unfold(Player starter, PlayerGroup players, Card firstCard)
    {
        LapCards lapCards = [new PlayerCard(firstCard, 0, starter.Index)];

        foreach (var (index, player) in players.FindWaitingPlayers(starter))
        { 
            var lapCard = player.TryFindSameCardByColor(firstCard.Color, index);
            lapCards.Add(lapCard);
        }

        return lapCards;
    }
}