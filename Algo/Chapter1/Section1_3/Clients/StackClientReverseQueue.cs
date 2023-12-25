namespace Algo.Chapter1.Section1_3;

public class StackClientReverseQueue()
{
    public void ReverseQueue(IQueue<int> q)
    {
        var stack = new LinkedListStack<int>();
        while (!q.IsEmpty())
        {
            stack.Push(q.Dequeue());
        }
        while (!stack.IsEmpty())
        {
            q.Enqueue(stack.Pop());
        }
    }
}
