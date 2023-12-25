using System.Collections;

namespace Algo.Chapter1.Section1_3;

public class LinkedListQueue<T> : IQueue<T>
{

    private Node? first;
    private Node? last;
    private int size;

    private class Node
    {
        public T Item { get; set; }
        public Node? Next { get; set; }
    }

    public T Dequeue()
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

    public void Enqueue(T item)
    {
        var oldLast = last;
        last = new Node { Item = item, Next = null };
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


    public bool IsEmpty() => first is null;

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
