namespace Joker;

public record Card6(CardColor color) : Card(color)
{
    public override int Weight => 1;
}