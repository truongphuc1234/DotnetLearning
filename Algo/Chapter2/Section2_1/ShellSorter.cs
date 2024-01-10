using Algo.Chapter2.Helper;
namespace Algo.Chapter2.Section2_1;

public class ShellSorter
{
    public void Sort<T>(T[] a) where T : IComparable<T>
    {
        int n = a.Length;
        int h = 1;
        while (h < n / 3)
        {
            h = 3 * h + 1;
        }
        while (h >= 1)
        {
            for (int i = h; i < n; i++)
            {
                for (int j = i; j >= h && a[j].Less(a[j - h]); j -= h)
                {
                    a.Exchange<T>(j, j - h);
                }
            }
            h /= 3;
        }
    }
}
