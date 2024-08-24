namespace Joker;

public abstract record Card(CardColor color)
{
    public string Name  => GetType().Name; 
   
   public abstract int Weight { get; }

    public CardColor Color { get; set; } = color;
}