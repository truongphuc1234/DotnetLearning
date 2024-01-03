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

    [Fact]
    public void Test_Ex_1_3_29()
    {
        var queue = new CircularLinkedList<int>();
        queue.Enqueue(1);
        queue.Enqueue(2);
        Assert.Equal(new int[] { 1, 2 }, queue.ToArray());
        Assert.Equal(2, queue.Size());
        Assert.Equal(1, queue.Dequeue());
        Assert.Equal(2, queue.Dequeue());
        Assert.True(queue.IsEmpty());
        Assert.Equal(new int[] { }, queue.ToArray());
    }

    [Fact]
    public void Test_Ex_1_3_30()
    {
        var client = new ClientLinkedList();
        var node1 = new Node<int> { Item = 1, Next = null };
        client.Insert(node1, 5);
        client.Insert(node1, 4);
        client.Insert(node1, 3);
        client.Insert(node1, 2);
        var result = client.Reverse<int>(node1);
        Assert.Equal(5, result.Item);
    }

    [Fact]
    public void Test_Ex_1_3_32()
    {
        var steque = new LinkedListSteque<int>();

        steque.Push(1);
        Assert.Equal(1, steque.Pop());
        steque.Enqueue(9);
        steque.Push(1);
        steque.Push(3);
        Assert.Equal(new int[] { 3, 1, 9 }, steque.ToArray());
        Assert.Equal(3, steque.Pop());
        Assert.Equal(1, steque.Pop());
    }

    [Fact]
    public void Test_Ex_1_3_33()
    {
        var deque = new LinkedListDeque<int>();

        deque.PushLeft(9);
        deque.PushRight(1);
        deque.PushRight(3);
        deque.PushLeft(4);
        Assert.Equal(new int[] { 4, 9, 1, 3 }, deque.ToArray());
        Assert.Equal(4, deque.PopLeft());
        Assert.Equal(3, deque.PopRight());
        Assert.Equal(9, deque.PopLeft());
        Assert.Equal(1, deque.PopLeft());
    }

    [Fact]
    public void Test_Ex_1_3_33_2()
    {
        var deque = new ResizingArrayDeque<int>();

        deque.PushLeft(9);
        deque.PushRight(1);
        deque.PushRight(3);
        deque.PushLeft(4);
        Assert.Equal(new int[] { 4, 9, 1, 3 }, deque.ToArray());
        Assert.Equal(4, deque.PopLeft());
        Assert.Equal(3, deque.PopRight());
        Assert.Equal(9, deque.PopLeft());
        Assert.Equal(1, deque.PopLeft());
    }

    [Fact]
    public void Test_Ex_1_3_34()
    {
        var deque = new RandomBag<int>();

        deque.Add(9);
        deque.Add(1);
        deque.Add(3);
        deque.Add(4);
        var result = deque.ToArray();
        Assert.Equal(4, result.Length);
        Assert.IsType<int>(result.Single(x => x == 9));
        Assert.IsType<int>(result.Single(x => x == 1));
        Assert.IsType<int>(result.Single(x => x == 3));
        Assert.IsType<int>(result.Single(x => x == 4));
    }

    [Fact]
    public void Test_Ex_1_3_35()
    {
        var deque = new QueueClientDealBridge();

        var result = deque.DealBridge();
        Assert.Equal(4, result.Length);
    }

    [Fact]
    public void Test_Ex_1_3_37()
    {
        var deque = new QueueClientJosephusProblem();

        var result = deque.Resolve(2, 7);
        Assert.Equal(new int[] { 1, 3, 5, 0, 4, 2, 6 }, result);
    }
}
