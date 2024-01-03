using System.Collections;

namespace Algo.Chapter1.Section1_3;

public class CircularLinkedList<T> : IQueue<T>
{
    private Node? last;
    private int size;

    private class Node
    {
        public T Item { get; set; }
        public Node? Next { get; set; }
    }

    public T Dequeue()
    {
        if (last is null)
        {
            throw new Exception("Queue is empty");
        }
        var item = last.Next!.Item;
        if (last.Next == last)
        {
            last = null;
        }
        else
        {
            last.Next = last.Next.Next;
        }
        size--;
        return item;
    }

    public void Enqueue(T item)
    {
        if (last is null)
        {
            last = new Node { Item = item, Next = null };
            last.Next = last;
        }
        else
        {
            var oldLast = last;
            last = new Node { Item = item, Next = null };
            last.Next = oldLast.Next;
            oldLast!.Next = last;
        }
        size++;
    }

    public bool IsEmpty() => last is null;

    public int Size() => size;

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public IEnumerator<T> GetEnumerator()
    {
        if (last is not null)
        {
            var current = last.Next;
            yield return current!.Item;
            current = current.Next;
            while (current != last.Next)
            {
                yield return current!.Item;
                current = current.Next;
            }
        }
    }
}
