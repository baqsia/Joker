using Joker.Laps;

namespace Joker.Cards;

public class NineCardDeck : List<Card>
{
    public virtual LapType LapType => LapType.IncementalEights;

    private static readonly IEnumerable<Card> _cards = [
        new Card6(CardColor.Clubs),
        new Card6(CardColor.Diamods),
        new CardJocker(CardColor.Clubs),
        new CardJocker(CardColor.Diamods),

        new Card7(CardColor.Clubs),
        new Card7(CardColor.Diamods),
        new Card7(CardColor.Spikes),
        new Card7(CardColor.Hearts),

        new Card8(CardColor.Clubs),
        new Card8(CardColor.Diamods),
        new Card8(CardColor.Spikes),
        new Card8(CardColor.Hearts),

        new Card9(CardColor.Clubs),
        new Card9(CardColor.Diamods),
        new Card9(CardColor.Spikes),
        new Card9(CardColor.Hearts),

        new Card10(CardColor.Clubs),
        new Card10(CardColor.Diamods),
        new Card10(CardColor.Spikes),
        new Card10(CardColor.Hearts),

        new CardJack(CardColor.Clubs),
        new CardJack(CardColor.Diamods),
        new CardJack(CardColor.Spikes),
        new CardJack(CardColor.Hearts),

        new CardQueen(CardColor.Clubs),
        new CardQueen(CardColor.Diamods),
        new CardQueen(CardColor.Spikes),
        new CardQueen(CardColor.Hearts),

        new CardKing(CardColor.Clubs),
        new CardKing(CardColor.Diamods),
        new CardKing(CardColor.Spikes),
        new CardKing(CardColor.Hearts),

        new CardAce(CardColor.Clubs),
        new CardAce(CardColor.Diamods),
        new CardAce(CardColor.Spikes),
        new CardAce(CardColor.Hearts)
    ];

    public NineCardDeck() : base(_cards.Shuffle()) { }

    public virtual void Distribute(int runIndex, Action<Card, int> callback)
    {
        var distributeIndex = 0;
        var cards = new NineCardDeck();
        while (cards.Any())
        {
            callback(cards.RandomCard(), distributeIndex);

            if (distributeIndex == 3)
                distributeIndex = 0;
            else
                distributeIndex++;
        }
    }

    protected Card RandomCard()
    {
       var item = this[Random.Shared.Next(0, Count - 1)];
       Remove(item);
       return item;
    }
}