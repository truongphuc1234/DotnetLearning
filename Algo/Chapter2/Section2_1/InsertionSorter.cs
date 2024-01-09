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
}
