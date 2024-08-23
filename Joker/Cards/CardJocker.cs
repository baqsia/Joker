namespace Joker;

public record CardJocker(CardColor color) : Card(color)
{
    public override int Weight => 2;
}