using Algo.Chapter2.Helper;

namespace Algo.Chapter2.Section2_2;

public class MergeSorterBU<T> where T : IComparable<T>
{
    private T[] aux = new T[0];

    public void Sort(T[] a)
    {
        int n = a.Length;
        aux = new T[n];
        for (int size = 1; size < n; size *= 2)
        {
            for (int low = 0; low < n - size; low += size * 2)
            {
                Merge(a, low, low + size - 1, Math.Min(low + 2 * size - 1, n - 1));
            }
        }
    }


    private void Merge(T[] a, int low, int mid, int high)
    {
        int i = low;
        int j = mid + 1;
        for (int k = low; k <= high; k++)
        {
            aux[k] = a[k];
        }
        for (int k = low; k <= high; k++)
        {
            if (i > mid)
            {
                a[k] = aux[j];
                j++;
            }
            else if (j > high)
            {
                a[k] = aux[i];
                i++;
            }
            else if (aux[i].Less(aux[j]))
            {
                a[k] = aux[i];
                i++;
            }
            else
            {
                a[k] = aux[j];
                j++;
            }
        }
    }
}
