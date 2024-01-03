namespace Algo.Chapter1.Section1_3;

public class QueueClientDealBridge()
{
    public Card[][] DealBridge()
    {
        var result = new Card[4][];
        var queue = new ResizingArrayRandomQueue<Card>();
        for (int i = 1; i <= 13; i++)
        {
            for (int j = 1; j <= 4; j++)
            {
                queue.Enqueue(new Card { Number = i, Type = j });
            }
        }
        for (int i = 0; i < 4; i++)
        {
            var arr = new Card[13];
            for (int j = 0; j < 13; j++)
            {
                arr[i] = queue.Dequeue();
            }
            result[i] = arr;
        }
        return result;
    }
}

public class Card
{
    public int Number;
    public int Type;
}
