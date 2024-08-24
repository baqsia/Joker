using Joker.Laps;

namespace Joker.Players;

public class PlayerGroup : LinkedList<Player>
{
    public bool IsFull() => Count == 4;

    public void FindRandomStarter()
    {
        var random = Random.Shared.Next(0, 3);
        this[random].Starter = true;
    }

    public Player Starter()
        => this.First(a => a.Starter);
    
    internal Player LapWinner() 
        => this.MaxBy(a => a.WinCount)!;

    internal void ResetCards()
    {
        foreach (var item in this)
        {
            item.ResetCards();
        }
    }

    internal IEnumerable<(int Index, Player Player)> FindWaitingPlayers(Player starter)
        =>  this.Where(player => player != starter) 
            .Select(a => (a.Index, this[a.Index]));

    internal Player FindDominantCardWinner(LapCards lapCards)
        => this.ElementAt(
            lapCards
                .TryFindDominantCard()
                .PlayerIndex
        );

    internal Player FindTrumpCardWinner(LapCards lapCards, CardColor trump)
        =>  this.ElementAt(
                lapCards
                    .TryFindTrumpDominantCard(trump)
                    .PlayerIndex
            );

    public Player this[int index]
    {
        get
        {
            return this.ElementAt(index);
        }
    }
}