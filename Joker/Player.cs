using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Joker;

public record Player(string Name, int Index)
{
    private PlayerCards _cards = new([]);

    public bool Starter { get; set; }
    public int WinCount { get; private set; }

    public void AddCard(Card card)
    {
        _cards.Push(card);
    }

    public CardColor? AskForATrump()
    {
        return new CardColorPool().PeekRandom();
    }

    internal void IncreaseWins()
    {
        WinCount++;
    }

    internal Card FindRandomCard()
    {
        var randomCard = _cards.Pop();
        return randomCard;
    }

    internal PlayerCard TryFindSameCardByColor(CardColor color, int cardIndex)
    {
        var cardCount = _cards.Count(a => a.Color == color);
        if(cardCount > 0)
        {
            var randomCard = _cards.Where(a => a.Color == color)
                                    .MaxBy(a => a.Weight)!; //We can go without Weight, by using Random
           
            var newCards = _cards.Where(a => a != randomCard).ToArray();
            _cards = new PlayerCards(newCards);
            return new PlayerCard(randomCard, cardIndex, Index);
        }
        
        {
            var temp = _cards.ToArray();
            var randomCard = temp[Random.Shared.Next(0, _cards.Count - 1)]; //We can go without random, by using Weight
            _cards = new PlayerCards(temp);
            return new PlayerCard(randomCard, cardIndex, Index);
        }
    }
}

public record PlayerCard(Card Card, int CardIndex, int PlayerIndex);


public class PlayerCards : Stack<Card>
{
    public PlayerCards(IEnumerable<Card> cards) : base(cards)
    {
    }
}
