namespace Example3;

public class ExampleClass3
{
    private IList<string> c = new List<string>();

    public void DoSomething()
    {
        var input = new[] { 75, 22, 36 };
        var output = input.Select(x => DoSomethingOne(x)).Select(x => DoSomethingTwo(x)).Select(x => DoSomethingThree(x)).ToArray();
    }

    public int DoSomethingOne(int x)
    {
        c.Add(DateTime.Now + " - DoSomeThingOne (" + x + ")");
        return x;
    }

    public int DoSomethingTwo(int x)
    {
        c.Add(DateTime.Now + " - DoSomeThingTwo (" + x + ")");
        return x;
    }

    public int DoSomethingThree(int x)
    {
        c.Add(DateTime.Now + " - DoSomeThingThree (" + x + ")");
        return x;
    }
}

