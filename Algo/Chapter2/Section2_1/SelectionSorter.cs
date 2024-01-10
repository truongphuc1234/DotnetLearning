using Algo.Chapter2.Helper;

namespace Algo.Chapter2.Section2_1;

public class SelectionSorter
{
    public void Sort<T>(T[] a) where T : IComparable<T>
    {
        var n = a.Length;
        for (int i = 0; i < n; i++)
        {
            int min = i;
            for (int j = i + 1; j < n; j++)
            {
                if (a[j].Less(a[min]))
                {
                    min = j;
                }
            }
            a.Exchange<T>(i ,min);
        }
    }
}
