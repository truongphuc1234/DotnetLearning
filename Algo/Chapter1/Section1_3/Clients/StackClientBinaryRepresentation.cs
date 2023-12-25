namespace Algo.Chapter1.Section1_3;

public class StackClientBinaryRepresentation()
{
    public string BinaryRepresentation(int n)
    {
        var stack = new LinkedListStack<int>();
        var remain = n;
        while (remain > 0)
        {
            stack.Push(remain % 2);
            remain = remain / 2;
        }
        return string.Join("", stack.ToArray());
    }
}

public class StackClientCopy
{
    public LinkedListStack<T> Copy<T>(LinkedListStack<T> stack)
    {
        var temp = new LinkedListStack<T>();
        var clone = new LinkedListStack<T>();
        foreach (T item in stack)
        {
            temp.Push(item);
        }
        foreach (T item in temp)
        {
            clone.Push(temp.Pop());
        }
        return clone;
    }
}
