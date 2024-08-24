namespace Joker.Players;

public record Player(string Name, int Index)
{
    private PlayerCards _cards = new([]);

    public bool Starter { get; set; }
    public int WinCount { get; private set; }
    public int Score { get; set; }

    public void AddCard(Card card)
        => _cards.Add(card);

    public CardColor? AskForATrump()
        => new CardColorPool().PeekRandom();

    internal void IncreaseWins()
    {
        WinCount++;
        Score += WinCount;
    }

    internal Card FindRandomCard()
    {
        var card = _cards[Random.Shared.Next(_cards.Count)];
        _cards.Remove(card);
        return card;
    }

    internal PlayerCard TryFindSameCardByColor(CardColor color, int cardIndex)
    {
        var cardCount = _cards.Count(a => a.Color == color);
        if(cardCount > 0)
        {
            var randomTrumpCard = _cards.Where(a => a.Color == color)
                                    .MaxBy(a => a.Weight)!; //We can go without Weight, by using Random
            
            _cards = new PlayerCards(_cards.Where(a => a != randomTrumpCard).ToArray());
            return new PlayerCard(randomTrumpCard, cardIndex, Index);
        }
        
        var randomCard = _cards[Random.Shared.Next(0, _cards.Count - 1)];
          
        _cards = new PlayerCards(_cards.Where(a => a != randomCard).ToArray());
        return new PlayerCard(randomCard, cardIndex, Index);
    }

    internal void ResetCards()
    {
        _cards = new([]);
        WinCount = 0;
    }
}
