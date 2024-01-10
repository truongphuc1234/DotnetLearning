using Algo.Chapter2.Helper;

namespace Algo.Chapter2.Section2_1;

public class InsertionSorter
{
    public void Sort<T>(T[] a) where T : IComparable<T>
    {
        for (int i = 1; i < a.Length; i++)
        {
            for (int j = i; j > 0 && a[j].Less(a[j - 1]); j--)
            {
                a.Exchange(j, j - 1);
            }
        }
    }

    public void SortWithoutExchange<T>(T[] a) where T : IComparable<T>
    {
        for (int i = 1; i < a.Length; i++)
        {
            var key = a[i];
            var j = i;
            while (j > 0 && key.Less(a[j - 1]))
            {
                a[j] = a[j - 1];
                j--;
            }
            a[j] = key;
        }
    }

    public void SortWithSentinel<T>(T[] a) where T : IComparable<T>
    {
        var min = 0;
        for (int i = 1; i < a.Length; i++)
        {
            if (a[i].Less(a[min]))
            {
                min = i;
            }
        }
        a.Exchange(min, 0);
        for (int i = 1; i < a.Length; i++)
        {
            for (int j = i - 1; a[j + 1].Less(a[j]); j--)
            {
                a.Exchange(j + 1, j);
            }
        }
    }
}
