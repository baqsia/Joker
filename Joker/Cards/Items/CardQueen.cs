namespace Joker;

public record CardQueen(CardColor color) : Card(color)
{
    public override int Weight => 7;
}