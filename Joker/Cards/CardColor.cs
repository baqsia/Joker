namespace Joker;

public enum CardColor
{
    Clubs,
    Spikes,
    Hearts,
    Diamods
}


public class CardColorPool: List<CardColor>
{
    public CardColorPool(): base([
        CardColor.Clubs, 
        CardColor.Spikes, 
        CardColor.Hearts, 
        CardColor.Diamods
    ])
    {
        
    }

    public CardColor? PeekRandom()
    {
        var ingoreColor = Random.Shared.Next(0, 1);
        if(ingoreColor == 0)
            return null;

        var randomIndex = Random.Shared.Next(0, 3);
        return this[randomIndex];
    }
}
