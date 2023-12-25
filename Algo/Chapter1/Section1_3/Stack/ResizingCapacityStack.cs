using System.Collections;

namespace Algo.Chapter1.Section1_3;

public class ResizingCapacityStack<T> : IStack<T>
{
    private T[] arr = new T[1];
    private int size = 0;

    public IEnumerator<T> GetEnumerator()
    {
        var current = size;
        while (current > 0)
        {
            current--;
            yield return arr[current];
        }
    }

    public bool IsEmpty()
    {
        return size == 0;
    }

    public T Peek()
    {
        return arr[size - 1];
    }

    public T Pop()
    {
        size--;
        return arr[size];
    }

    public void Push(T item)
    {
        if (size == arr.Length)
        {
            Resize(2 * arr.Length);
        }
        arr[size] = item;
        size++;
    }

    public int Size()
    {
        return size;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    private void Resize(int max)
    {
        T[] temp = new T[max];
        for (int i = 0; i < this.size; i++)
        {
            temp[i] = arr[i];
        }
        arr = temp;
    }
}
