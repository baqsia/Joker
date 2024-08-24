namespace Joker;

public record CardAce(CardColor color) : Card(color)
{
    public override int Weight => 9;
}