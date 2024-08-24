
using Joker.Cards;
using Joker.Players;

namespace Joker.Laps;

public record LapRunner(Lap Lap)
{
    public void RunEach(PlayerGroup players, CardColor? trump)
    {
        var deck = Deck();

        for (int runIndex = Lap.Times; runIndex > 0; runIndex--)
        {
            deck.Distribute(runIndex, (card, index) =>
            {
                players[index].AddCard(card);
            });

            int lapIndex = 0;
            var starter = players.Starter();
            var index = Lap.Index();
            while (lapIndex < index)
            {
                 var lapWinner = Lap.Run(starter, players, trump);
                 lapWinner.IncreaseWins();

                 starter = lapWinner;
                 System.Console.WriteLine($"Lap '{lapIndex+1}' won: {lapWinner}");
                 lapIndex++;
            } 
            var winner = players.LapWinner();
            System.Console.WriteLine($"The winner is: {winner.Name}");
            players.ResetCards();
        }
    }

    public NineCardDeck Deck()
    {
        return Lap.LapType switch
        {
            LapType.IncementalEights => new EightIncrementalCardDeck(),
            LapType.Nines or _ => new NineCardDeck(),
        };
    }
}