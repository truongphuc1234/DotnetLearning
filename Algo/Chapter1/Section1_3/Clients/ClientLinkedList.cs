namespace Algo.Chapter1.Section1_3;

public class Node<T>
{
    public T? Item { get; set; }
    public Node<T>? Next { get; set; }
}

public class ClientLinkedList
{
    public void DeleteLast<T>(Node<T> first)
    {
        var current = first;
        while (current.Next?.Next is not null)
        {
            current = current.Next;
        }
        current.Next = null;
    }

    public void Delete<T>(Node<T>? first, int k)
    {
        if (k == 1)
        {
            first = null;
        }
        int i = 1;
        var current = first;
        while (i < k && current is not null)
        {
            current = current.Next;
            i++;
        }
        if (current is not null)
        {
            current.Next = current.Next?.Next;
        }
    }

    public Node<T>? Find<T>(Node<T>? first, T key)
    {
        var current = first;
        if (key is null)
        {
            return null;
        }
        while (current is not null)
        {
            if (key.Equals(current.Item))
            {
                return current;
            }
            current = current.Next;
        }
        return null;
    }

    public void Insert<T>(Node<T> node, T value)
    {
        var newNode = new Node<T> { Item = value, Next = node.Next };
        node.Next = newNode;
    }

    public void RemoveAfter<T>(Node<T> node)
    {
        if (node.Next is not null)
        {
            node.Next = node.Next.Next;
        }
    }

    public void InsertAfter<T>(Node<T> node, Node<T> insertingNode)
    {
        insertingNode.Next = node.Next;
        node.Next = insertingNode;
    }

    public Node<T>? Remove<T>(Node<T> first, T key)
    {
        var clonedNode = first;
        if (key is null)
        {
            return clonedNode;
        }
        var current = clonedNode;
        Node<T>? previous = null;
        while (current is not null)
        {
            if (key.Equals(current.Item))
            {
                if (previous is not null)
                {
                    previous.Next = current.Next;
                    current = current.Next;
                }
                else
                {
                    clonedNode = current.Next;
                    current = clonedNode;
                }
            }
            else
            {
                previous = current;
                current = current.Next;
            }
        }
        return clonedNode;
    }

    public T? Max<T>(Node<T> first)
        where T : IComparable<T>
    {
        T? max = default;
        var current = first;
        while (current is not null)
        {
            if (current.Item is not null && current.Item.CompareTo(max) > 0)
            {
                max = current.Item;
            }
            current = current.Next;
        }
        return max;
    }

    public T? MaxRecursive<T>(Node<T> first)
        where T : IComparable<T>
    {
        if (first.Next is not null)
        {
            var max = MaxRecursive(first.Next);
            if (first.Item is not null && first.Item.CompareTo(max) > 0)
            {
                return first.Item;
            }
            else
            {
                return max;
            }
        }
        else
        {
            return first.Item;
        }
    }
}
