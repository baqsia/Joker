namespace Joker;

public record Card10(CardColor color) : Card(color)
{
    public override int Weight => 10;
}