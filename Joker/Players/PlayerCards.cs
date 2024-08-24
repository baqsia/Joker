namespace Joker.Players;

public class PlayerCards(IEnumerable<Card> cards) : List<Card>(cards);