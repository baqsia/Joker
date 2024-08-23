namespace Joker;

public record Card8(CardColor color) : Card(color)
{
    public override int Weight => 3;
}