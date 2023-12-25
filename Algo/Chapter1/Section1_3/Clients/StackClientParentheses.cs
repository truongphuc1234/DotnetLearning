namespace Algo.Chapter1.Section1_3;

public class StackClientParentheses
{
    public bool IsParenthesesBalanced(string str)
    {
        var dict = new Dictionary<char, char>()
        {
            { ']', '[' },
            { '}', '{' },
            { ')', '(' }
        };
        var stack = new LinkedListStack<char>();
        foreach (char s in str)
        {
            if (dict.TryGetValue(s, out char val))
            {
                if (val == stack.Peek())
                {
                    stack.Pop();
                }
                else
                {
                    stack.Push(s);
                }
            }
            else
            {
                stack.Push(s);
            }
        }
        return stack.IsEmpty();
    }
}
