using System.Collections;

namespace Algo.Chapter1.Section1_3;

public class LinkedListDeque<T> : IDeque<T>
{
    private Node? first;
    private Node? last;
    private int size;

    private class Node
    {
        public T Item { get; set; }
        public Node? Next { get; set; }
        public Node? Prev { get; set; }
    }

    public T PopLeft()
    {
        if (IsEmpty())
        {
            throw new Exception("Queue is empty");
        }
        var item = first!.Item;
        first = first.Next;
        size--;
        if (IsEmpty())
        {
            last = null;
        }
        return item;
    }

    public T PopRight()
    {
        if (IsEmpty())
        {
            throw new Exception("Queue is empty");
        }
        var item = last!.Item;
        last = last.Prev;
        size--;
        if (IsEmpty())
        {
            first = null;
        }
        return item;
    }

    public void PushRight(T item)
    {
        var oldLast = last;
        last = new Node
        {
            Item = item,
            Next = null,
            Prev = last
        };
        if (IsEmpty())
        {
            first = last;
        }
        else
        {
            oldLast!.Next = last;
        }
        size++;
    }

    public void PushLeft(T item)
    {
        var oldFirst = first;
        first = new Node
        {
            Item = item,
            Next = first,
            Prev = null
        };
        if (IsEmpty())
        {
            last = first;
        }
        else
        {
            oldFirst!.Prev = first;
        }
        size++;
    }

    public bool IsEmpty() => first is null || last is null;

    public int Size() => size;

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
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
}
