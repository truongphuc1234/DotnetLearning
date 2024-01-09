using Algo.Chapter1.Section1_3;

namespace Algo.Chapter2.Section2_1;

public class DeckSorter
{
    public void Sort(Card[] cards)
    {
        for (int i = 1; i < cards.Length; i++)
        {
            for (int j = i; j > 0 && cards[j].Less(cards[j - 1]); j--)
            {
                cards.Exchange(j, j - 1);
            }
        }
    }

    public Card[] DequeueSort(Card[] cards)
    {
        var deque = new LinkedListDeque<Card>();
        foreach (Card card in cards)
        {
            deque.PushRight(card);
        }
        var hasSwap = true;
        while (hasSwap)
        {
            hasSwap = false;
            for (int i = 0; i < cards.Length - 1; i++)
            {
                var card1 = deque.PopLeft();
                var card2 = deque.PopLeft();
                if (card1.Less(card2))
                {
                    deque.PushLeft(card2);
                    deque.PushRight(card1);
                }
                else
                {
                    deque.PushLeft(card1);
                    deque.PushRight(card2);
                    hasSwap = true;
                }
            }
            deque.PushRight(deque.PopLeft());
        }
        return deque.ToArray();
    }

    public Card[] PrepareCards()
    {
        var cards = new Card[52];
        var index = 0;
        for (int i = 0; i < 4; i++)
        {
            for (int j = 1; j <= 13; j++)
            {
                cards[index] = new Card { Suit = (Suit)i, Rank = j };
                index++;
            }
        }
        cards.Shuffle();
        return cards;
    }
}

public class Card : IComparable<Card>
{
    public Suit Suit;
    public int Rank;

    public int CompareTo(Card? other)
    {
        if (other is null)
        {
            return 1;
        }
        if (this.Suit == other.Suit)
        {
            return this.Rank - other.Rank;
        }
        return this.Suit - other.Suit;
    }
}

public enum Suit
{
    Spade = 0,
    Heart,
    Club,
    Diamond
}
