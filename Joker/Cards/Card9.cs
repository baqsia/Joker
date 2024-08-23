namespace Joker;

public record Card9(CardColor color) : Card(color)
{
    public override int Weight => 4;
}