using System.Collections;

namespace Algo.Chapter1.Section1_3;

public class Bag<T> : IBag<T>
{
    private Node? first;
    private int size;

    private class Node
    {
        public T Item { get; set; }
        public Node? Next { get; set; }
    }

    public void Add(T item)
    {
        var oldFirst = first;
        first = new Node { Item = item, Next = oldFirst };
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
