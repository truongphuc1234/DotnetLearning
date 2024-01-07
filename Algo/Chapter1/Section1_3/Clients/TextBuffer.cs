namespace Algo.Chapter1.Section1_3;

public class TextBuffer
{
    private IStack<char> left = new LinkedListStack<char>();
    private IStack<char> right = new LinkedListStack<char>();

    public void Insert(char c)
    {
        left.Push(c);
    }

    public char Delete()
    {
        if (!right.IsEmpty())
        {
            return right.Pop();
        }
        return default;
    }

    public void Left(int k)
    {
        var i = k;
        while (!left.IsEmpty() && i > 0)
        {
            right.Push(left.Pop());
            i--;
        }
    }

    public void Right(int k)
    {
        var i = k;
        while (!right.IsEmpty() && i > 0)
        {
            left.Push(right.Pop());
            i--;
        }
    }
}
