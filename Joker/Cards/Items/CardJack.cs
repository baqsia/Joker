namespace Joker;

public record CardJack(CardColor color) : Card(color)
{
    public override int Weight => 6;
}