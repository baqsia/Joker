using Joker.Laps;
using Joker.Players;

namespace Joker;

public class Deck
{
    private PlayerGroup _players = [];
    private CardColor? _trump;
    private Lap? _lap;

    public Deck AcceptPlayer(Player player)
    {
        if (!_players.IsFull())
            _players.AddLast(player);

        return this;
    }

    public Deck PrepareForStart()
    {
        RandomGameType();
        ChooseRandomStarter();
        AskForTrump();

        return this;
    }

    public void Start()
    {
        var runner = new LapRunner(_lap!);
        runner.RunEach(_players, _trump);
    }

    private void ChooseRandomStarter()
    {
        _players.FindRandomStarter();
    }

    private void AskForTrump()
    {
        _trump = _players.Starter()
                         .AskForATrump();
    }

    private void RandomGameType()
    {
        _lap = new OneEightLap();//Random.Shared.Next(0, 1) == 1
                // ? new NineLap()
                // : new OneEightLap();
    }
}
