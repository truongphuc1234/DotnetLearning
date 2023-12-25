using System.Collections;

namespace Algo.Chapter1.Section1_3;

public class LinkedListStack<T> : IStack<T>
{
    private Node? first;
    private int size = 0;

    private class Node
    {
        public T Item { get; set; } = default;
        public Node? Next { get; set; }
    }

    public IEnumerator<T> GetEnumerator()
    {
        var current = first;
        while (current is not null)
        {
            yield return current.Item;
            current = current.Next;
        }
    }

    public bool IsEmpty()
    {
        return first is null;
    }

    public T Pop()
    {
        if (first is null)
        {
            throw new Exception("Stack Underflow");
        }
        var item = first.Item;
        first = first.Next;
        size--;
        return item;
    }

    public void Push(T item)
    {
        var oldHead = first;
        first = new Node() { Item = item, Next = oldHead };
        size++;
    }

    public T Peek()
    {
        if (first is null)
        {
            throw new Exception("Stack Underflow");
        }
        return first.Item;
    }

    public int Size()
    {
        return size;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
