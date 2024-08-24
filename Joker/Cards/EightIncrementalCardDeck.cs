using Joker.Laps;

namespace Joker.Cards;

public class EightIncrementalCardDeck : NineCardDeck
{
    public override LapType LapType => LapType.IncementalEights;
    
    public override void Distribute(int runIndex, Action<Card, int> callback)
    {
        var cards = new EightIncrementalCardDeck();
        var distributeIndex = 0;
        var index = runIndex + 1;
        while (distributeIndex < index - 1)
        {
            for (int i = 0; i < 4; i++)
            {
                callback(cards.RandomCard(), i);
            }
 
            distributeIndex++;
        }
    }
}