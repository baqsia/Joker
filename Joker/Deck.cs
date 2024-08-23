
namespace Joker;

public class Deck
{
    private Players _players = [];
    private int randomStartIndex = 0;
    private CardColor? _trump;
 
    internal void AcceptPlayer(Player player)
    {
        if(!_players.IsFull())
            _players.AddLast(player);
    }

    internal void ChooseRandomStarter()
    {
        var random = Random.Shared.Next(0, 3);
        randomStartIndex = random;
        _players.ElementAt(randomStartIndex).Starter = true;
    }
 
    internal void ShuffleCards()
    {
        var pool = new CardPool();
        pool.Distribute((card, index) => 
        {
            _players.ElementAt(index)
                    .AddCard(card);
        });
    }

    private void AskForTrump()
    {
        _trump = _players.ElementAt(randomStartIndex).AskForATrump();
    }

    internal void StartGame()
    {
        ChooseRandomStarter();
        ShuffleCards();
        AskForTrump();

        int lapIndex = 0;
        while(lapIndex < 9)
        {
            var lap = new Lap(lapIndex);
            var starter = _players.ElementAt(randomStartIndex);
            var lapWinner = lap.Run(starter, _players, _trump);
            _players.Find(lapWinner)?.Value.IncreaseWins();

            System.Console.WriteLine($"Lap winnder is {lapWinner.Name}");
            lapIndex++;
            System.Console.WriteLine($"Lap index: {lapIndex}");
        }

        var winner = _players.MaxBy(a => a.WinCount);
        System.Console.WriteLine(winner);
    }
}

public class Players : LinkedList<Player>
{
    public bool IsFull() => Count == 4;
}