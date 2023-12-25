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
        Assert.Equal(new int[] { 2, 1 }, stack.ToArray());
        Assert.Equal(2, stack.Size());
        Assert.Equal(2, stack.Pop());
        Assert.Equal(1, stack.Pop());
        Assert.True(stack.IsEmpty());
    }

    [Fact]
    public void TestResizedCapacityStack_Work()
    {
        var stack = new ResizingCapacityStack<int>();
        stack.Push(1);
        stack.Push(2);
        Assert.Equal(new int[] { 2, 1 }, stack.ToArray());
        Assert.Equal(2, stack.Size());
        Assert.Equal(2, stack.Pop());
        Assert.Equal(1, stack.Pop());
        Assert.True(stack.IsEmpty());
    }

    [Fact]
    public void TestLinkedListStack_Work()
    {
        var stack = new LinkedListStack<int>();
        stack.Push(1);
        stack.Push(2);
        Assert.Equal(new int[] { 2, 1 }, stack.ToArray());
        Assert.Equal(2, stack.Size());
        Assert.Equal(2, stack.Pop());
        Assert.Equal(1, stack.Pop());
        Assert.True(stack.IsEmpty());
    }

    [Fact]
    public void TestLinkedListQueue()
    {
        var queue = new LinkedListQueue<int>();
        queue.Enqueue(1);
        queue.Enqueue(2);
        Assert.Equal(new int[] { 1, 2 }, queue.ToArray());
        Assert.Equal(2, queue.Size());
        Assert.Equal(1, queue.Dequeue());
        Assert.Equal(2, queue.Dequeue());
        Assert.True(queue.IsEmpty());
    }

    [Fact]
    public void TestResizingArrayQueue()
    {
        var queue = new ResizingArrayQueue<int>();
        queue.Enqueue(1);
        queue.Enqueue(2);
        Assert.Equal(new int[] { 1, 2 }, queue.ToArray());
        Assert.Equal(2, queue.Size());
        Assert.Equal(1, queue.Dequeue());
        Assert.Equal(2, queue.Dequeue());
        Assert.True(queue.IsEmpty());
    }

    [Fact]
    public void Test_Ex_1_3_2()
    {
        var stack = new LinkedListStack<string>();
        var str = "it was - the best - of times - - - it was - the - -";
        foreach (string s in str.Split(" "))
        {
            if (s == "-")
            {
                stack.Pop();
            }
            else
            {
                stack.Push(s);
            }
        }
        Assert.Equal("it", string.Join(" ", stack.ToArray()));
    }

    [Fact]
    public void Test_Ex_1_3_4_True()
    {
        var str = "[()]{}{[()()]()}";
        var client = new StackClientParentheses();
        Assert.True(client.IsParenthesesBalanced(str));
    }

    [Fact]
    public void Test_Ex_1_3_4_False()
    {
        var str = "[(])";
        var client = new StackClientParentheses();
        Assert.False(client.IsParenthesesBalanced(str));
    }

    [Fact]
    public void Test_Ex_1_3_5()
    {
        var num = 50;
        var client = new StackClientBinaryRepresentation();
        Assert.Equal("110010", client.BinaryRepresentation(num));
    }

    [Fact]
    public void Test_Ex_1_3_6()
    {
        var queue = new LinkedListQueue<int>();
        queue.Enqueue(1);
        queue.Enqueue(2);
        queue.Enqueue(3);
        var client = new StackClientReverseQueue();
        client.ReverseQueue(queue);
        Assert.Equal([3, 2, 1], queue.ToArray());
    }

    [Fact]
    public void Test_Ex_1_3_9()
    {
        var str = "1 + 2 ) * 3 - 4 ) * 5 - 6 ) ) )";
        var client = new StackClientFillParentheses();
        Assert.Equal("( ( 1 + 2 ) * ( ( 3 - 4 ) * ( 5 - 6 ) ) )", client.FillParentheses(str));
    }

    [Fact]
    public void Test_Ex_1_3_12()
    {
        var stack = new LinkedListStack<int>();
        stack.Push(1);
        stack.Push(2);
        var client = new StackClientCopy();
        var clonedStack = client.Copy<int>(stack);
        Assert.Equal(new int[] { 2, 1 }, clonedStack.ToArray());
        Assert.Equal(2, clonedStack.Size());
        Assert.Equal(2, clonedStack.Pop());
        Assert.Equal(1, clonedStack.Pop());
        Assert.True(clonedStack.IsEmpty());
    }

    [Fact]
    public void Test_Ex_1_3_19()
    {
        var node1 = new Node<int> { Item = 1, Next = null };
        var node2 = new Node<int> { Item = 2, Next = null };
        var node3 = new Node<int> { Item = 3, Next = null };
        node1.Next = node2;
        node2.Next = node3;
        var client = new ClientLinkedList();
        client.DeleteLast(node1);
        Assert.Null(node2.Next);
    }

    [Fact]
    public void Test_Ex_1_3_20()
    {
        var node1 = new Node<int> { Item = 1, Next = null };
        var node2 = new Node<int> { Item = 2, Next = null };
        var node3 = new Node<int> { Item = 3, Next = null };
        var node4 = new Node<int> { Item = 4, Next = null };
        node1.Next = node2;
        node2.Next = node3;
        node3.Next = node4;
        var client = new ClientLinkedList();
        client.Delete(node1, 2);
        Assert.Equal(4, node1.Next?.Next?.Item);
    }

    [Fact]
    public void Test_Ex_1_3_21()
    {
        var node1 = new Node<int> { Item = 1, Next = null };
        var node2 = new Node<int> { Item = 2, Next = null };
        var node3 = new Node<int> { Item = 3, Next = null };
        var node4 = new Node<int> { Item = 4, Next = null };
        node1.Next = node2;
        node2.Next = node3;
        node3.Next = node4;
        var client = new ClientLinkedList();
        var result = client.Find(node1, 2);
        Assert.Equal(2, result?.Item);
    }

    [Fact]
    public void Test_Ex_1_3_22()
    {
        var node1 = new Node<int> { Item = 1, Next = null };
        var node2 = new Node<int> { Item = 2, Next = null };
        var node3 = new Node<int> { Item = 3, Next = null };
        var node4 = new Node<int> { Item = 4, Next = null };
        node1.Next = node2;
        node2.Next = node3;
        node3.Next = node4;
        var client = new ClientLinkedList();
        client.Insert(node1, 5);
        Assert.Equal(5, node1.Next?.Item);
        Assert.Equal(2, node1.Next?.Next?.Item);
    }

    [Fact]
    public void Test_Ex_1_3_24()
    {
        var client = new ClientLinkedList();
        var node1 = new Node<int> { Item = 1, Next = null };
        client.Insert(node1, 5);
        client.Insert(node1, 4);
        client.Insert(node1, 3);
        client.Insert(node1, 2);
        client.RemoveAfter(node1?.Next!);
        Assert.Equal(4, node1?.Next?.Next?.Item);
    }

    [Fact]
    public void Test_Ex_1_3_25()
    {
        var client = new ClientLinkedList();
        var node1 = new Node<int> { Item = 1, Next = null };
        client.Insert(node1, 5);
        client.Insert(node1, 4);
        client.Insert(node1, 3);
        client.Insert(node1, 2);
        client.InsertAfter(node1.Next!, new Node<int> { Item = 6, Next = null });
        Assert.Equal(6, node1.Next?.Next?.Item);
    }

    [Fact]
    public void Test_Ex_1_3_26()
    {
        var client = new ClientLinkedList();
        var node1 = new Node<int> { Item = 1, Next = null };
        client.Insert(node1, 5);
        client.Insert(node1, 4);
        client.Insert(node1, 3);
        client.Insert(node1, 2);
        var newNode = client.Remove<int>(node1, 2);
        Assert.Equal(3, newNode?.Next?.Item);
        newNode = client.Remove<int>(newNode!, 1);
        Assert.Equal(3, newNode?.Item);
    }

    [Fact]
    public void Test_Ex_1_3_27()
    {
        var client = new ClientLinkedList();
        var node1 = new Node<int> { Item = 1, Next = null };
        client.Insert(node1, 5);
        client.Insert(node1, 4);
        client.Insert(node1, 3);
        client.Insert(node1, 2);
        var result = client.Max<int>(node1);
        Assert.Equal(5, result);
    }

    [Fact]
    public void Test_Ex_1_3_28()
    {
        var client = new ClientLinkedList();
        var node1 = new Node<int> { Item = 1, Next = null };
        client.Insert(node1, 5);
        client.Insert(node1, 4);
        client.Insert(node1, 3);
        client.Insert(node1, 2);
        var result = client.MaxRecursive<int>(node1);
        Assert.Equal(5, result);
    }
}
