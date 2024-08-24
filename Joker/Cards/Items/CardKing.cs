namespace Joker;

public record CardKing(CardColor color) : Card(color)
{
    public override int Weight => 8;
}