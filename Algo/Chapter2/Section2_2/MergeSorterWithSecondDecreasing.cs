using Algo.Chapter2.Helper;

namespace Algo.Chapter2.Section2_2;

public class MergeSorterWithSecondDecreasing<T> : MergeSorter<T> where T : IComparable<T>
{
    protected override void Merge(T[] a, int low, int mid, int high)
    {
        int i = low;
        int j = high;
        for (int k = low; k <= mid; k++)
        {
            aux[k] = a[k];
        }
        for (int k = mid + 1; k <= high; k++)
        {
            aux[k] = a[high - k + mid + 1];
        }
        for (int k = low; i <= j; k++)
        {
            if (aux[i].Less(aux[j]))
            {
                a[k] = aux[i];
                i++;
            }
            else
            {
                a[k] = aux[j];
                j--;
            }
        }
    }
}
