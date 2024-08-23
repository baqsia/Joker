namespace Joker;

public record Card7(CardColor color) : Card(color)
{
    public override int Weight => 2;
}