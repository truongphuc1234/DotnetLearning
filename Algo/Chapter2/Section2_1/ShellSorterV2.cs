namespace Algo.Chapter2.Section2_1;

public class ShellSorterV2
{
    public void Sort<T>(T[] a) where T : IComparable<T>
    {
        int n = a.Length;
        var num = (int)Math.Floor(Math.Log(2 * n + 1, 3));
        for (int k = num; k > 0; k--)
        {
            int h = (int)((Math.Pow(3, k) - 1) / 2);
            for (int i = h; i < n; i++)
            {
                for (int j = i; j >= h && a[j].Less(a[j - h]); j -= h)
                {
                    a.Exchange(j, j - h);
                }
            }
        }
    }
}
