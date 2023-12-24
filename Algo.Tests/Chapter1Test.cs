using Algo.Chapter1.Section1_3;

namespace Algo.Tests;

public class Chapter1Test
{
    [Fact]
    public void TestFixedCapacityStack_Work()
    {
        var stack = new FixedCapacityStack<int>(10);
        stack.Push(1);
        stack.Push(2);
        Assert.Equal(2, stack.Size());
        Assert.Equal(2, stack.Pop());
        Assert.Equal(1, stack.Pop());
        Assert.True(stack.IsEmpty());
    }

    [Fact]
    public void TestResizedCapacityStack_Work()
    {
        var stack = new ResizedCapacityStack<int>();
        stack.Push(1);
        stack.Push(2);
        foreach (int item in stack)
        {
            Assert.Equal(2, item);
        }
        Assert.Equal(2, stack.Size());
        Assert.Equal(2, stack.Pop());
        Assert.Equal(1, stack.Pop());
        Assert.True(stack.IsEmpty());
    }
}
