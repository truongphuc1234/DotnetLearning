using System.Collections;

namespace Algo.Chapter1.Section1_3;

public class ResizingArrayDeque<T> : IDeque<T>
{
    private T[] arr = new T[1];
    private int first;
    private int last;
    private int size;

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
            var index = i + first;
            if (index >= arr.Length)
            {
                index -= arr.Length;
            }
            yield return arr[index];
        }
    }

    private void Resize(int max)
    {
        T[] temp = new T[max];
        for (int i = 0; i < this.size; i++)
        {
            var index = i + first;
            if (index >= arr.Length)
            {
                index -= arr.Length;
            }
            temp[i] = arr[index];
        }
        arr = temp;
        first = 0;
        last = size - 1;
    }

    public void PushLeft(T item)
    {
        if (size == arr.Length)
        {
            Resize(2 * arr.Length);
        }
        first--;
        size++;
        if (first < 0)
        {
            first = arr.Length - 1;
        }
        arr[first] = item;
    }

    public void PushRight(T item)
    {
        if (size == arr.Length)
        {
            Resize(2 * arr.Length);
        }
        last++;
        size++;
        if (last == arr.Length)
        {
            last = 0;
        }
        arr[last] = item;
    }

    public T PopRight()
    {
        if (IsEmpty())
        {
            throw new Exception("Queue is empty");
        }
        var item = arr[last];
        arr[last] = default;
        last--;
        size--;
        if (last < 0)
        {
            last = arr.Length - 1;
        }
        if (size == arr.Length / 4)
        {
            Resize(arr.Length / 2);
        }
        return item;
    }

    public T PopLeft()
    {
        if (IsEmpty())
        {
            throw new Exception("Queue is empty");
        }
        var item = arr[first];
        arr[first] = default;
        first++;
        size--;
        if (first == arr.Length)
        {
            first = 0;
        }
        if (size == arr.Length / 4)
        {
            Resize(arr.Length / 2);
        }
        return item;
    }
}
