using System.Collections;

namespace Algo.Chapter1.Section1_3;

public class FixedCapacityStack<T> : IStack<T>
{
    private T[] arr;
    private int head = 0;

    public FixedCapacityStack(int capacity)
    {
        arr = new T[capacity];
    }

    public IEnumerator<T> GetEnumerator()
    {
        var current = head;
        while (current < 0)
        {
            yield return arr[current];
            current--;
        }
    }

    public bool IsEmpty()
    {
        return head == 0;
    }

    public T Pop()
    {
        return arr[--head];
    }

    public void Push(T item)
    {
        arr[head++] = item;
    }

    public int Size()
    {
        return head;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
