namespace Algo.Chapter1.Section1_3;

public class StackClientFillParentheses
{
    public string FillParentheses(string str)
    {
        var ops = new LinkedListStack<string>();
        var vals = new LinkedListStack<string>();
        foreach (string s in str.Split(" "))
        {
            switch (s)
            {
                case ")":
                    var second = vals.Pop();
                    var first = vals.Pop();
                    var op = ops.Pop();
                    vals.Push($"( {first} {op} {second} )");
                    break;
                case "+":
                case "-":
                case "*":
                    ops.Push(s);
                    break;
                default:
                    vals.Push(s);
                    break;
            }
        }
        return vals.Pop();
    }
}
