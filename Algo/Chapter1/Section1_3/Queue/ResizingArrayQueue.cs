using System.Collections;

namespace Algo.Chapter1.Section1_3;

public class ResizingArrayQueue<T> : IQueue<T>
{
    protected T[] arr = new T[1];
    protected int first;
    protected int last;
    protected int size;

    public virtual T Dequeue()
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

    public virtual void Enqueue(T item)
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

    protected void Resize(int max)
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
}
