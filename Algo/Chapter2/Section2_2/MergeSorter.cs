using Algo.Chapter2.Helper;

namespace Algo.Chapter2.Section2_2;

public class MergeSorter<T> where T : IComparable<T>
{
    protected T[] aux = new T[0];

    public void Sort(T[] a)
    {
        aux = new T[a.Length];
        Sort(a, 0, a.Length - 1);
    }

    protected void Sort(T[] a, int low, int high)
    {
        if (high <= low) { return; }
        int mid = (low + high) / 2;
        Sort(a, low, mid);
        Sort(a, mid + 1, high);
        Merge(a, low, mid, high);
    }

    protected virtual void Merge(T[] a, int low, int mid, int high)
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
