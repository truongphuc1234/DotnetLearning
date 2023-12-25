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
        while (current > 0)
        {
            current--;
            yield return arr[current];
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

    public bool IsFull()
    {
        return head == arr.Length;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public T Peek()
    {
        return arr[head - 1];
    }
}
