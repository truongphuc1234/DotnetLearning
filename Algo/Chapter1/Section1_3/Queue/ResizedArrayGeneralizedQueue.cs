using System.Collections;

namespace Algo.Chapter1.Section1_3;

public class ResizingArrayGeneralizedQueue<T> : IGeneralizedQueue<T>
{
    protected T[] arr = new T[1];
    protected int size;

    public T Delete(int k)
    {
        if (IsEmpty())
        {
            throw new Exception("Queue is empty");
        }
        if (k <= 0 || k > size)
        {
            throw new Exception("Out of range");
        }
        var item = arr[k - 1];
        for (int i = k - 1; i < size - 1; i++)
        {
            arr[i] = arr[i + 1];
        }
        arr[size - 1] = default;
        size--;
        if (size == arr.Length / 4)
        {
            Resize(arr.Length / 2);
        }
        return item;
    }

    public void Insert(T item)
    {
        if (size == arr.Length)
        {
            Resize(2 * arr.Length);
        }
        arr[size] = item;
        size++;
    }

    public bool IsEmpty() => size == 0;

    public int Size() => size;

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < this.size; i++)
        {
            yield return arr[i];
        }
    }

    protected void Resize(int max)
    {
        T[] temp = new T[max];
        for (int i = 0; i < this.size; i++)
        {
            temp[i] = arr[i];
        }
        arr = temp;
    }
}
